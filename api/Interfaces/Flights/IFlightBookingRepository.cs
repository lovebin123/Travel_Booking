using System;
using api.Models;
using api.Models.Flights;

namespace api.Interfaces.Flights
{
    public interface IFlightBookingRepository : IRepository<FlightBookingEntity>
    {
        Task<IEnumerable<FlightBookingEntity>> GetUserFlightBookings(AppUser user);
        Task<FlightBookingEntity?> GetById(int id);
        Task<FlightBookingEntity> CreateAsync(FlightBookingEntity flightBooking);
    }
}
