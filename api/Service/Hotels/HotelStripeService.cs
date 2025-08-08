using api.Interfaces.Hotels;
using api.Models.Hotels;
using Stripe;
using Stripe.Checkout;

namespace api.Service.Hotels
{
    public class HotelStripeService:IHotelStripeService
    {
        private readonly IHotelBookingRepository _hotelBookingRepo;
        private readonly IHotelStripeRepository _hotelStripeRepo;

        public HotelStripeService(IHotelBookingRepository hotelBookingRepo, IHotelStripeRepository hotelStripeRepo)
        {
            StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("STRIPE_ID");
            _hotelBookingRepo = hotelBookingRepo;
            _hotelStripeRepo = hotelStripeRepo;
        }

        public async Task<Session> CreateCheckoutSession(int bookingId)
        {
            var booking = await _hotelBookingRepo.GetById(bookingId);
            if (booking == null)
                throw new Exception("Booking not found");

            var sessionOptions = new SessionCreateOptions
            {
                CustomerEmail = booking.user.Email,
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "inr",
                            UnitAmountDecimal = (decimal?)booking.price * 100,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = booking.hotel.name,
                                Images = new List<string>
                                {
                                    "https://cf.bstatic.com/xdata/images/hotel/square240/630261077.webp?k=3a13c1266c4a9a38b604af00cc650e49228bcc4b8379de4fad3f079a7ebe5a81&o="
                                }
                            }
                        },
                        Quantity = 1
                    }
                },
                Mode = "payment",
                SuccessUrl = $"http://localhost:5253/api/hotelBooking/success?sessionId={{CHECKOUT_SESSION_ID}}&booking_id={bookingId}",
                CancelUrl = "http://localhost:4200/paymentFailure"
            };

            var sessionService = new SessionService();
            return sessionService.Create(sessionOptions);
        }

        public async Task<HotelPaymentEntity> HandleStripeSuccess(string sessionId, int bookingId)
        {
            var booking = await _hotelBookingRepo.GetById(bookingId);
            if (booking == null)
                throw new Exception("Booking not found");

            var sessionService = new SessionService();
            var session = sessionService.Get(sessionId);

            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = paymentIntentService.Get(session.PaymentIntentId);

            var chargeService = new ChargeService();
            var charge = chargeService.Get(paymentIntent.LatestChargeId);

            var payment = new HotelPaymentEntity
            {
                stripe_payement_intent_id = session.PaymentIntentId,
                status = session.PaymentStatus,
                sessionId = session.Id,
                amount = (session.AmountTotal ?? 0) / 100.0,
                bookingId = booking.id,
                card = charge.PaymentMethodDetails.Card.Brand,
                booking_date = DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd"),
                booking_time = TimeOnly.FromDateTime(DateTime.Now).ToString("hh:mm tt")
            };

            booking.isBooked = 1;
            booking.paymentId = payment.stripe_payement_intent_id;

            await _hotelStripeRepo.CreateHotelPayment(payment);
            return payment;
        }
    }
}
