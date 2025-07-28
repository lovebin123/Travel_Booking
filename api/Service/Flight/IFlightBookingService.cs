using api.Models;
using api.Models.Flights;

namespace api.Service.Flight
{
    public interface IFlightBookingService
    {
        Task<FlightBooking> CreateBookingAsync(AppUser user, int flightId, int noOfAdults, int noOfChildren);
        Task<List<FlightBooking>> GetUserBookingsAsync(AppUser user);
    }
}
