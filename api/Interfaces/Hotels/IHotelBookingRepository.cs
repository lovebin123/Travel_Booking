using System;
using api.Models;
using api.Models.Hotels;

namespace api.Interfaces.Hotels
{
    public interface IHotelBookingRepository:IGenericRepository<HotelBooking>
    {
        Task<List<HotelBooking>> GetUserBookings(AppUser user);
        
    }
}
