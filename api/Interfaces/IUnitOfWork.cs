using api.Interfaces.Flights;

namespace api.Interfaces
{
    public interface IUnitOfWork
    {
        IFlightRepository FlightRepository { get; }
        IFlightBookingRepository FlightBookingRepository { get; }
        IFlightPaymentRepository FlightPaymentRepository { get; }
        Task<int> SaveAsync();
    }
}
