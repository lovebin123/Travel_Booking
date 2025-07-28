using api.Models;
using api.Models.Hotels;

namespace api.Service.Hotels
{
    public interface IHotelPaymentService
    {
        Task<HotelPayment?> GetLastPaymentAndUpdateRooms(string sessionId);
        Task<List<HotelPayment>> GetHotelPayments(AppUser user);
        Task<HotelPayment> GetById(string id);
    }
}
