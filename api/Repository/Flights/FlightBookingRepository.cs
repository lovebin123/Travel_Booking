using System;
using api.Data;
using api.Interfaces.Flights;
using api.Models;
using api.Models.Flights;
using api.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Flights
{
    public class FlightBookingRepository : GenericRepository<FlightBookingEntity>,IFlightBookingRepository
    {
        private readonly ApplicationDBContext _context;
        public FlightBookingRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<FlightBookingEntity> CreateAsync(FlightBookingEntity flightBooking)
        {
            await _context.FlightBookings.AddAsync(flightBooking);
            await _context.SaveChangesAsync();
            return flightBooking;
        }

        public async Task<FlightBookingEntity?> GetById(int id)
        {
         return await _context.FlightBookings.Include(ft=>ft.Flight).Include(u=>u.AppUser).FirstOrDefaultAsync(x => x.id == id);

        }
        public async Task<IEnumerable<FlightBookingEntity>> GetUserFlightBookings(AppUser user)
        {
            
            return await _context.FlightBookings.Where(u => u.user_id == user.Id).Select(fb => new FlightBookingEntity
            {
                id = fb.id,
                user_id = fb.user_id,
                isBooked = fb.isBooked,
                paymentId = fb.paymentId,
                Flight = new FlightEnitity
                {
                    id = fb.flight_id,
                    name = fb.Flight.name,
                    date_of_departure = fb.Flight.date_of_departure,
                    destination = fb.Flight.destination,
                    seatType = fb.Flight.seatType,
                    source = fb.Flight.source,
                    time_of_arrival = fb.Flight.time_of_arrival,
                    time_of_departure = fb.Flight.time_of_departure,

                },
                amount = fb.amount
            }).OrderByDescending(x => x.isBooked).ToListAsync();
        }

    }
}
