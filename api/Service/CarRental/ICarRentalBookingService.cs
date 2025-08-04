using api.DTO.Car_Rental;
using api.Models.Car_Rental;

namespace api.Service.CarRental
{
    public interface ICarRentalBookingService
    {
        Task<CarRentalBookingEntity> CreateBookingAsync(string userName, int carId, CreateCarRentalBookingDto dto);
        Task<List<CarRentalBookingEntity>> GetUserBookingsAsync(string userName);
        Task<string> CreateCheckoutSessionAsync(int bookingId);
        Task<CarRentalPaymentEntity> ProcessCheckoutSuccessAsync(string sessionId, int bookingId);
    }
}
