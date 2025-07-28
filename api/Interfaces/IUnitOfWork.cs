using api.Interfaces.Flights;
using api.Interfaces.Hotels;

namespace api.Interfaces
{
    public interface IUnitOfWork
    {
        IFlightRepository FlightRepository { get; }
        IFlightBookingRepository FlightBookingRepository { get; }
        IFlightPaymentRepository FlightPaymentRepository { get; }
        IHotelRepository HotelRepository { get; }
        IHotelBookingRepository HotelBookingRepository { get; }
        IHotelPaymentRepository HotelPaymentRepository { get; }
        Task<int> SaveAsync();
    }
}
