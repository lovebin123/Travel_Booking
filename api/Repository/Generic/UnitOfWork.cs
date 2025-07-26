using api.Data;
using api.Interfaces;
using api.Interfaces.Flights;
using api.Interfaces.Hotels;
using api.Repository.Flights;
using api.Repository.Hotels;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Generic
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IFlightRepository FlightRepository { get; }
        public IFlightBookingRepository FlightBookingRepository { get; }
        public IFlightPaymentRepository FlightPaymentRepository { get;  }
       public  IHotelRepository HotelRepository { get; }
        public IHotelBookingRepository HotelBookingRepository { get; }
        public IHotelPaymentRepository HotelPaymentRepository { get; }
        public FlightMapper flightMapper { get; }
        public UnitOfWork(ApplicationDBContext context,FlightMapper flightMapper)
        {
            _context= context;
            FlightRepository = new FlightRepository(_context);
            FlightBookingRepository = new FlightBookingRepository(_context);
            FlightPaymentRepository = new FlightPaymentRepository(_context);
            HotelRepository=new HotelRepository(_context);
            HotelBookingRepository=new HotelBookingRepository(_context);
            HotelPaymentRepository=new HotelPaymentRepository(_context);   


        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
