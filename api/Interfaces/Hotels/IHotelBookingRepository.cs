using System;
using api.Models;
using api.Models.Hotels;

namespace api.Interfaces.Hotels
{
    public interface IHotelBookingRepository
    {
        Task<HotelBookingEnitity> CreateHotelBooking(HotelBookingEnitity hotelBooking);
        Task<HotelBookingEnitity> GetById(int bookingId);
        Task<List<HotelBookingEnitity>> GetUserBookings(AppUser user);

        Task DeleteById(int id);

    }
}
