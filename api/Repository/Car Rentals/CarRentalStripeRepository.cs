using System;
using api.Data;
using api.Interfaces.Car_Rentals;
using api.Models.Car_Rental;
using Stripe;
using Stripe.Checkout;
using DotNetEnv;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613,8604,7022
namespace api.Repository.Car_Rentals
{
    public class CarRentalStripeRepository : ICarRentalStripeRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ICarRentalBookingRepository _carRentalBookingRepository;
        public CarRentalStripeRepository(ApplicationDBContext context, ICarRentalBookingRepository carRentalBookingRepository)
        {
            _context = context;
            _carRentalBookingRepository = carRentalBookingRepository;
            StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("STRIPE_ID"); ;
        }
        public async Task<Session> CreateCheckoutSession(int bookingId)
        {
            var booking = await _carRentalBookingRepository.GetById(bookingId);
            Console.WriteLine(booking);
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
                            UnitAmountDecimal = (decimal?)booking.amount*100,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = booking.carRental.car_name,
                                Images=new List<string>{"https://cdn2.rcstatic.com/images/car_images_b/web/nissan/versa_lrg.jpg"},
                            }
                        },
                        Quantity = 1
                    }
                },
                Mode = "payment",
                SuccessUrl = $"http://localhost:5253/api/carRentalBooking/success?sessionId={{CHECKOUT_SESSION_ID}}&bookingId={bookingId}",
                CancelUrl = "http://localhost:4200/paymentFailure"
            };
            var sessionService = new SessionService();
            Session session = sessionService.Create(sessionOptions);
            return session;
        }

        public async Task<CarRentalPaymentEntity> CreateCarRentalPayment(CarRentalPaymentEntity payment)
        {
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<CarRentalPaymentEntity> GetSuccess(string sessionId, int bookingId)
        {
            var sessionService = new SessionService();
            var session = sessionService.Get(sessionId);
            var booking = await _carRentalBookingRepository.GetById(bookingId);
            if (booking == null)
                throw new Exception("Booking not found");
            var payementIntentService = new PaymentIntentService();
            var paymentIntent = payementIntentService.Get(session.PaymentIntentId);
            var chargeId = paymentIntent.LatestChargeId;
            string card = null;
            var chargeService = new ChargeService();
            var charge = chargeService.Get(chargeId);
            card = charge.PaymentMethodDetails.Card.Brand;
            var payment = new CarRentalPaymentEntity
            {
                stripe_payement_intent_id = session.PaymentIntentId,
                status = session.PaymentStatus,
                sessionId = session.Id,
                amount = (session.AmountTotal ?? 0) / 100.0,
                bookingId = booking.id,
                card = card,
                booking_date = DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd"),
                booking_time = TimeOnly.FromDateTime(DateTime.Now).ToString("hh:mm tt")
            };
            booking.isBooked = 1;
            booking.carRental.is_available = false;
            booking.paymentId = session.PaymentIntentId;
            await _context.SaveChangesAsync();
            return payment;
        }
    }
}