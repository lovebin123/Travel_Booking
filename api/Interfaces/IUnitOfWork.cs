using api.Interfaces.Flights;
using api.Interfaces.Hotels;
using api.Models.Flights;

namespace api.Interfaces
{
    public interface IUnitOfWork
    {
        IFlightRepository FlightRepository { get; }
        IFlightBookingRepository FlightBookingRepository { get; }
        IStripePayementRepository StripePayementRepository { get; }
       IFlightPaymentRepository  FlightPaymentRepository { get; }
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task CompleteAsync();
    }
}
