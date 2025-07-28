using api.Models;
using api.Models.Hotels;

namespace api.Service.Hotels
{
    public interface IHotelBookingService
    {
        Task<HotelBooking> CreateHotelBooking(HotelBooking booking);
        Task<HotelBooking> GetById(int id);
        Task<List<HotelBooking>> GetUserBookings(AppUser user);
        Task<object> CreateStripeSession(int bookingId);
        Task<object> HandleStripeSuccess(string sessionId, int bookingId);
        Task<Hotel> GetHotelById(int id);
    }
}
