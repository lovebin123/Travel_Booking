using api.Data;
using api.Interfaces;
using api.Interfaces.Flights;
using api.Repository.Flights;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Generic
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IFlightRepository FlightRepository { get; }
        public IFlightBookingRepository FlightBookingRepository { get; }
        public IFlightPaymentRepository FlightPaymentRepository { get;  }
        public FlightMapper flightMapper { get; }
        public UnitOfWork(ApplicationDBContext context,FlightMapper flightMapper)
        {
            _context= context;
            FlightRepository = new FlightRepository(_context);
            FlightBookingRepository = new FlightBookingRepository(_context);
            FlightPaymentRepository = new FlightPaymentRepository(_context);
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
