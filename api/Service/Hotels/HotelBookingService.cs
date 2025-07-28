using api.Interfaces.Hotels;
using api.Models;
using api.Models.Hotels;

namespace api.Service.Hotels
{
    public class HotelBookingService : IHotelBookingService
    {
        private readonly IHotelBookingRepository _bookingRepo;
        private readonly IHotelRepository _hotelRepository;
        private readonly IHotelStripeService _stripeService; 

        public HotelBookingService(
            IHotelBookingRepository bookingRepo,
            IHotelRepository hotelRepository,
            IHotelStripeService stripeService)
        {
            _bookingRepo = bookingRepo;
            _hotelRepository = hotelRepository;
            _stripeService = stripeService;
        }

        public async Task<HotelBooking> CreateHotelBooking(HotelBooking booking)
        {
            return await _bookingRepo.CreateHotelBooking(booking);
        }

        public async Task<HotelBooking> GetById(int id)
        {
            return await _bookingRepo.GetById(id);
        }

        public async Task<List<HotelBooking>> GetUserBookings(AppUser user)
        {
            return await _bookingRepo.GetUserBookings(user);
        }

        public async Task<object> CreateStripeSession(int bookingId)
        {
            return await _stripeService.CreateCheckoutSession(bookingId); 
        }

        public async Task<object> HandleStripeSuccess(string sessionId, int bookingId)
        {
            return await _stripeService.HandleStripeSuccess(sessionId, bookingId); 
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            return await _hotelRepository.GetById(id);
        }
    }
}
