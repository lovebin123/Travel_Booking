using api.Interfaces.Flights;
using api.Interfaces.Hotels;

namespace api.Interfaces
{
    public interface IUnitOfWork
    {
        IFlightRepository FlightRepository { get; }
        IFlightBookingRepository FlightBookingRepository { get; }
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task CompleteAsync();
    }
}
