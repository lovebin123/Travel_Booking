using System;
using api.Models;
using api.Models.Car_Rental;

namespace api.Interfaces.Car_Rentals
{
    public interface ICarRentalBookingRepository
    {
        Task<CarRentalBooking> CreateCarRentalBooking(CarRentalBooking carRentalBooking);
        Task<List<CarRentalBooking>> GetUserCarRentalBookings(AppUser user);
        Task<CarRentalBooking> GetById(int id);
        Task<CarRentalBooking> DeleteById(int id);
    }
}
