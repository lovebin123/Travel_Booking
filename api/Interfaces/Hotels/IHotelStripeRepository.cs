using System;
using api.Models.Hotels;
using Stripe.Checkout;

namespace api.Interfaces.Hotels
{
    public interface IHotelStripeRepository
    {
        Task<HotelPayment> CreateHotelPayment(HotelPayment payment);

    }
}
