using api.Models;
using api.Models.Flights;

namespace api.Service.Flight
{
    public interface IFlightPaymentService
    {
        Task<List<FlightPayement>> GetAllPaymentsAsync(AppUser user);
        Task<FlightPayement?> GetByPaymentIntentIdAsync(string id);
        Task<FlightPayement?> GetLatestPaymentAsync(string sessionId);
    }
}
