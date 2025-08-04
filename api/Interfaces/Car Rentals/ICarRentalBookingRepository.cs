using System;
using api.Models;
using api.Models.Car_Rental;

namespace api.Interfaces.Car_Rentals
{
    public interface ICarRentalBookingRepository
    {
        Task<CarRentalBookingEntity> CreateCarRentalBooking(CarRentalBookingEntity carRentalBooking);
        Task<List<CarRentalBookingEntity>> GetUserCarRentalBookings(AppUser user);
        Task<CarRentalBookingEntity> GetById(int id);
        Task<CarRentalBookingEntity> DeleteById(int id);
    }
}
