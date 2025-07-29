using api.DTO.Car_Rental;
using api.Models.Car_Rental;

namespace api.Service.CarRental
{
    public interface ICarRentalBookingService
    {
        Task<CarRentalBooking> CreateBookingAsync(string userName, int carId, CreateCarRentalBookingDTO dto);
        Task<List<CarRentalBooking>> GetUserBookingsAsync(string userName);
        Task<string> CreateCheckoutSessionAsync(int bookingId);
        Task<CarRentalPayment> ProcessCheckoutSuccessAsync(string sessionId, int bookingId);
    }
}
