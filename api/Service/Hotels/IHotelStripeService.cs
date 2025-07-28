using api.Models.Hotels;
using Stripe;
using Stripe.Checkout;

namespace api.Service.Hotels
{
    public interface IHotelStripeService
    {
        Task<Session> CreateCheckoutSession(int bookingId);
        Task<HotelPayment> HandleStripeSuccess(string sessionId, int bookingId);
    }
}
