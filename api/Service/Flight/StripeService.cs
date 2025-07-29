using api.Interfaces;
using api.Interfaces.Flights;
using api.Models.Flights;
using Stripe;
using Stripe.Checkout;
namespace api.Service.Flight
{
    public class StripeService : IStripeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StripeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("STRIPE_ID");
        }

        public async Task<Session> CreateFlightBookingPaymentSession(int bookingId)
        {
            var booking = await _unitOfWork.FlightBookingRepository.GetById(bookingId);
            if (booking == null || booking.Flight == null || booking.AppUser == null)
                throw new Exception("Invalid booking details");

            var sessionOptions = new SessionCreateOptions
            {
                CustomerEmail = booking.AppUser.Email,
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "inr",
                            UnitAmountDecimal = (decimal?)booking.amount * 100,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = booking.Flight.name,
                                Images = new List<string> { "https://imgak.mmtcdn.com/flights/assets/media/dt/common/icons/AI.png?v=20" },
                            }
                        },
                        Quantity = 1
                    }
                },
                Mode = "payment",
                SuccessUrl = $"http://localhost:5253/api/flightBooking/success?sessionId={{CHECKOUT_SESSION_ID}}&booking_id={bookingId}",
                CancelUrl = "http://localhost:4200/failure"
            };

            var sessionService = new SessionService();
            return sessionService.Create(sessionOptions);
        }

        public async Task<FlightPayement> HandleSuccessfulPayment(string sessionId, int bookingId)
        {
            var sessionService = new SessionService();
            var session = sessionService.Get(sessionId);

            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = paymentIntentService.Get(session.PaymentIntentId);

            var chargeService = new ChargeService();
            var charge = chargeService.Get(paymentIntent.LatestChargeId);

            var booking = await _unitOfWork.FlightBookingRepository.GetById(bookingId);
            if (booking == null)
                throw new Exception("Booking not found");

            booking.isBooked = 1;
            booking.paymentId = session.PaymentIntentId;

            var payment = new FlightPayement
            {
                stripe_payement_intent_id = session.PaymentIntentId,
                payement_status = session.PaymentStatus,
                amount = (session.AmountTotal ?? 0) / 100.0,
                FlightBookingId = booking.id,
                sessionId = session.Id,
                card = charge.PaymentMethodDetails.Card.Brand
            };

            await _unitOfWork.StripePayementRepository.SavePaymentAsync(payment);

            await _unitOfWork.CompleteAsync();

            return payment;
        }
    }
}
