using api.Models;
using api.Models.Hotels;

namespace api.Service.Hotels
{
    public interface IHotelPaymentService
    {
        Task<HotelPaymentEntity?> GetLastPaymentAndUpdateRooms(string sessionId);
        Task<List<HotelPaymentEntity>> GetHotelPayments(AppUser user);
        Task<HotelPaymentEntity> GetById(string id);
    }
}
