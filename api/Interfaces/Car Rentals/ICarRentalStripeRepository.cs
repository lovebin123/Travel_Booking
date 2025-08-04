using System;
using api.Models.Car_Rental;
using Stripe.Checkout;

namespace api.Interfaces.Car_Rentals
{
    public interface ICarRentalStripeRepository
    {
        Task<Session> CreateCheckoutSession(int bookingId);
        Task<CarRentalPaymentEntity> CreateCarRentalPayment(CarRentalPaymentEntity payment);
        Task<CarRentalPaymentEntity> GetSuccess(string sessionId, int bookingId);
    }
}
