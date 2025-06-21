using System;
using api.Models.Hotels;
using Stripe.Checkout;

namespace api.Interfaces.Hotels
{
    public interface IHotelStripeRepository
    {
        Task<Session> CreateCheckoutSession(int bookingId);
        Task<HotelPayment> CreateHotelPayment(HotelPayment payment);
        Task<HotelPayment> GetSuccess(string sessionId, int bookingId);
    }
}
