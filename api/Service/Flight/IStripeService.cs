using api.Models.Flights;
using Stripe.Checkout;
using Stripe;
using api.DTO.Flight;

namespace api.Service.Flight
{
    public interface IStripeService
    {
        Task<Session> CreateFlightBookingPaymentSession(int bookingId);
        Task<ResponseFlightPaymentDto> HandleSuccessfulPayment(string sessionId, int bookingId);
    }
}
