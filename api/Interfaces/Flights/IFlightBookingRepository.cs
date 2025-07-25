using System;
using api.Models;
using api.Models.Flights;

namespace api.Interfaces.Flights
{
    public interface IFlightBookingRepository:IGenericRepository<FlightBooking>
    {
        Task<List<FlightBooking>>GetUserFlightBookings(AppUser user);
     
    }
}
