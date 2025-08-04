using System;
using api.Models;
using api.Models.Hotels;

namespace api.Interfaces.Hotels
{
    public interface IHotelPaymentRepository
    {
        Task<HotelPaymentEntity> GetById(string id);
        Task<List<HotelPaymentEntity>> GetHotelPayments(AppUser user);
        Task<HotelPaymentEntity?> GetLastPayment(string sessionId);
        Task SaveChangesAsync();
    }
}
