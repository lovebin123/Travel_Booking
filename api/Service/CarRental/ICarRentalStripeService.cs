using api.Models.Car_Rental;
using Stripe;
using Stripe.Checkout;

namespace api.Service.CarRental
{
    public interface ICarRentalStripeService
    {
        Task<string> CreateCheckoutSessionAsync(int bookingId);
        Task<CarRentalPaymentEntity> HandleSuccessfulPayment(string sessionId, int bookingId);
    }
}
