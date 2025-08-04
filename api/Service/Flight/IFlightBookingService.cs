using api.DTO.Flight;
using api.Models;
using api.Models.Flights;

namespace api.Service.Flight
{
    public interface IFlightBookingService
    {
        Task<ResponseFlightBookingDto> CreateBookingAsync(AppUser user, int flightId, int noOfAdults, int noOfChildren);
        Task<IEnumerable<ResponseFlightBookingDto>> GetUserBookingsAsync(AppUser user);
    }
}
