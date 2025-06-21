using System;
using api.Models.Flights;
using Stripe.Checkout;
namespace api.Interfaces.Flights
{
    public interface IStripePayementRepository
    {
        Task<Session> CreateFlightBookingPaymentSession(int bookingId);
            Task<FlightPayement> CreateFlightPayment(FlightPayement payment);
        Task<FlightPayement> GetSuccess(string sessionId, int bookingId);
    }
}
