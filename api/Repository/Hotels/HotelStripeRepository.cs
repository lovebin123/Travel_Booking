using System;
using api.Data;
using api.Interfaces.Hotels;
using api.Models.Hotels;
using DotNetEnv;
using Microsoft.AspNetCore.Http.HttpResults;
using Stripe;
using Stripe.Checkout;

namespace api.Repository.Hotels
{
    public class HotelStripeRepository : IHotelStripeRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IHotelBookingRepository _hotelBookingRepository;
        public HotelStripeRepository (IHotelBookingRepository hotelBookingRepository, ApplicationDBContext context)
        {
            StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("STRIPE_ID"); ;
            _hotelBookingRepository = hotelBookingRepository;
            _context = context;
        }
        public async Task<Session> CreateCheckoutSession(int bookingId)
        {
            var booking = await _hotelBookingRepository.GetById(bookingId);
            if (booking == null)
                throw new Exception("Booking not found");
            var sessionOptions = new SessionCreateOptions
            {
                CustomerEmail=booking.user.Email,
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "inr",
                            UnitAmountDecimal = (decimal?)booking.price*100,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = booking.hotel.name,
                                Images=new List<string>{"https://cf.bstatic.com/xdata/images/hotel/square240/630261077.webp?k=3a13c1266c4a9a38b604af00cc650e49228bcc4b8379de4fad3f079a7ebe5a81&o="},
                            }
                        },
                        Quantity = 1
                    }
                },
                Mode = "payment",
                SuccessUrl = $"http://localhost:5253/api/hotelBooking/success?sessionId={{CHECKOUT_SESSION_ID}}&booking_id={bookingId}",
                CancelUrl = "http://localhost:4200/failure"
            };
            var sessionService = new SessionService();
            Session session=sessionService.Create(sessionOptions);
            return session;
        }

        public async Task<HotelPayment> CreateHotelPayment(HotelPayment payment)
        {
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<HotelPayment> GetSuccess(string sessionId, int bookingId)
        {
            var sessionService = new SessionService();
            var session = sessionService.Get(sessionId);
            var booking = await _hotelBookingRepository.GetById(bookingId);
            if (booking == null)
                throw new Exception("Booking not found");
            var payementIntentService = new PaymentIntentService();
            var paymentIntent = payementIntentService.Get(session.PaymentIntentId);
            var chargeId = paymentIntent.LatestChargeId;
            string card = null;
            var chargeService = new ChargeService();
            var charge = chargeService.Get(chargeId);
            card = charge.PaymentMethodDetails.Card.Brand;
            var payment = new HotelPayment
            {
                stripe_payement_intent_id = session.PaymentIntentId,
                status = session.PaymentStatus,
                sessionId=session.Id,
                amount = (session.AmountTotal ?? 0) / 100.0,
                bookingId = booking.id,
                card = card,
                booking_date = DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd"),
                booking_time=TimeOnly.FromDateTime(DateTime.Now).ToString("hh:mm tt")
            };
            booking.isBooked = 1;
            booking.paymentId = payment.stripe_payement_intent_id;
            await _context.SaveChangesAsync();
            return payment;
    }
    }
}
