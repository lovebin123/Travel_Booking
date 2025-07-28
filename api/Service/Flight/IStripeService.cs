using api.Models.Flights;
using Stripe.Checkout;
using Stripe;

namespace api.Service.Flight
{
    public interface IStripeService
    {
        Task<Session> CreateFlightBookingPaymentSession(int bookingId);
        Task<FlightPayement> HandleSuccessfulPayment(string sessionId, int bookingId);
    }
}
