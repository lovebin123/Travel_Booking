using System;
using api.Models;
using api.Models.Hotels;

namespace api.Interfaces.Hotels
{
    public interface IHotelPaymentRepository
    {
        Task<HotelPayment> GetById(string id);
        Task<List<HotelPayment>> GetHotelPayments(AppUser user);
        Task<HotelPayment?> GetLastPayment(string sessionId);
        Task SaveChangesAsync();
    }
}
