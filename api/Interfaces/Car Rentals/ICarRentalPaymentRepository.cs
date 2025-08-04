using System;
using api.Models;
using api.Models.Car_Rental;

namespace api.Interfaces.Car_Rentals
{
    public interface ICarRentalPaymentRepository
    {
        Task<CarRentalPaymentEntity> GetLatestCarRentalPayment(string sessionId);
        Task<List<CarRentalPaymentEntity>> GetCarRentalPayments(AppUser user);
        Task<CarRentalPaymentEntity> GetById(string paymentId);
    }
}
