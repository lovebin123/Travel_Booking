using System;
using api.Models;
using api.Models.Flights;

namespace api.Interfaces.Flights
{
    public interface IFlightBookingRepository
    {
        Task<List<FlightBooking>>GetUserFlightBookings(AppUser user);
        Task<FlightBooking?> GetById(int id);
        Task<FlightBooking> CreateAsync(FlightBooking flightBooking);
    }
}
