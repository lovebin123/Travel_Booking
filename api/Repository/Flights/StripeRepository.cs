using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Interfaces.Flights;
using Stripe.Checkout;
using Stripe;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models.Flights;
using DotNetEnv;

namespace api.Service
{
    public class StripeRepository:IStripePayementRepository
    {
        private readonly IFlightBookingRepository _flightBookingRepository;
        private readonly ApplicationDBContext _context;
        public StripeRepository(IFlightBookingRepository flightBookingRepository, ApplicationDBContext context)
        {
            StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("STRIPE_ID");
            _flightBookingRepository = flightBookingRepository;
            _context = context;
        }

        public async Task<Session> CreateFlightBookingPaymentSession(int bookingId)
        {
            var flightBooking = await _flightBookingRepository.GetById(bookingId);
            if (flightBooking == null)
                throw new Exception("Booking or flight not found");
            var sessionOptions = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "inr",
                            UnitAmountDecimal = (decimal?)flightBooking.amount*100,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = flightBooking.Flight.name,
                                Images=new List<string>{"https://imgak.mmtcdn.com/flights/assets/media/dt/common/icons/AI.png?v=20%22"},
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
            Session session = sessionService.Create(sessionOptions);
            return session;
    
        }

        public async Task<FlightPayement> CreateFlightPayment(FlightPayement payment)
        {
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<FlightPayement> GetSuccess(string sessionId, int bookingId)
        {
            var sessionService = new SessionService();
            var session = sessionService.Get(sessionId);
            var booking = await _flightBookingRepository.GetById(bookingId);
            var payementIntentService = new PaymentIntentService();
            var paymentIntent = payementIntentService.Get(session.PaymentIntentId);
            var chargeId = paymentIntent.LatestChargeId;
            string card = null;
            var chargeService = new ChargeService();
            var charge = chargeService.Get(chargeId);
            card = charge.PaymentMethodDetails.Card.Brand;
            var payment = new FlightPayement
            {
                stripe_payement_intent_id = session.PaymentIntentId,
                payement_status = session.PaymentStatus,
                amount = (session.AmountTotal ?? 0) / 100.0,
                FlightBookingId = booking.id,
                sessionId = session.Id,
                card = card
            };
            booking.isBooked = 1;
            booking.paymentId =payment.stripe_payement_intent_id;
            await _context.SaveChangesAsync();
            return payment;
        }
    }
}
