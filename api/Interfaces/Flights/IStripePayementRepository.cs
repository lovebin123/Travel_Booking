using System;
using api.Models.Flights;
using Stripe.Checkout;
namespace api.Interfaces.Flights
{
    public interface IStripePayementRepository
    {
        Task SavePaymentAsync(FlightPayementEntity payment);

    }
}
