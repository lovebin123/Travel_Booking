using api.DTO.Flight;
using api.Models;
using api.Models.Flights;

namespace api.Service.Flight
{
    public interface IFlightPaymentService
    {
        Task<List<ResponseFlightPaymentDto>> GetAllPaymentsAsync(AppUser user);
        Task<ResponseFlightPaymentDto?> GetByPaymentIntentIdAsync(string id);
        Task<ResponseFlightPaymentDto?> GetLatestPaymentAsync(string sessionId);
    }
}
