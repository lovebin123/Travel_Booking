using api.Interfaces.Hotels;
using api.Models;
using api.Models.Hotels;

namespace api.Service.Hotels
{
    public class HotelPaymentService:IHotelPaymentService
    {
        private readonly IHotelPaymentRepository _paymentRepo;

        public HotelPaymentService(IHotelPaymentRepository paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        public async Task<HotelPaymentEntity?> GetLastPaymentAndUpdateRooms(string sessionId)
        {
            var payment = await _paymentRepo.GetLastPayment(sessionId);
            if (payment == null) return null;

            var rooms = payment.hotelBooking.no_of_rooms;
            if (payment.hotelBooking.hotel.no_of_rooms_available >= rooms)
            {
                payment.hotelBooking.hotel.no_of_rooms_available -= rooms;
                await _paymentRepo.SaveChangesAsync();
            }

            return payment;
        }

        public async Task<List<HotelPaymentEntity>> GetHotelPayments(AppUser user)
        {
            return await _paymentRepo.GetHotelPayments(user);
        }

        public async Task<HotelPaymentEntity> GetById(string id)
        {
            return await _paymentRepo.GetById(id);
        }
    }
}
