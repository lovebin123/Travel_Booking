using System;
using api.Models;
using api.Models.Hotels;

namespace api.Interfaces.Hotels
{
    public interface IHotelBookingRepository
    {
        Task<HotelBooking> CreateHotelBooking(HotelBooking hotelBooking);
        Task<HotelBooking> GetById(int bookingId);
        Task<List<HotelBooking>> GetUserBookings(AppUser user);

    }
}
