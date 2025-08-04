using api.Models;
using api.Models.Hotels;

namespace api.Service.Hotels
{
    public interface IHotelBookingService
    {
        Task<HotelBookingEnitity> CreateHotelBooking(HotelBookingEnitity booking);
        Task<HotelBookingEnitity> GetById(int id);
        Task<List<HotelBookingEnitity>> GetUserBookings(AppUser user);
        Task<object> CreateStripeSession(int bookingId);
        Task<object> HandleStripeSuccess(string sessionId, int bookingId);
        Task<HotelEntity> GetHotelById(int id);
    }
}
