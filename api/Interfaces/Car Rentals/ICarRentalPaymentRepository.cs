using System;
using api.Models;
using api.Models.Car_Rental;

namespace api.Interfaces.Car_Rentals
{
    public interface ICarRentalPaymentRepository
    {
        Task<CarRentalPayment> GetLatestCarRentalPayment(string sessionId);
        Task<List<CarRentalPayment>> GetCarRentalPayments(AppUser user);
        Task<CarRentalPayment> GetById(string paymentId);
    }
}
