using System;
using api.Data;
using api.Interfaces.Flights;
using api.Models;
using api.Models.Flights;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Flights
{
    public class FlightBookingRepository : IFlightBookingRepository
    {
        private readonly ApplicationDBContext _context;
        public FlightBookingRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<FlightBooking> AddAsync(FlightBooking flightBooking)
        {
            await _context.FlightBookings.AddAsync(flightBooking);
            await _context.SaveChangesAsync();
            return flightBooking;
        }

        public async Task DeleteAsync(int id)
        {
             var flights = await _context.FlightBookings.FirstOrDefaultAsync(x => x.id== id);
            _context.FlightBookings.Remove(flights);
            _context.SaveChanges();
        }

        public async Task<FlightBooking?> GetByIdAsync(int id)
        {
            return await _context.FlightBookings.FirstOrDefaultAsync(x => x.id == id);

        }

        public async Task<List<FlightBooking>> GetUserFlightBookings(AppUser user)
        {
            
            return await _context.FlightBookings.Where(u => u.user_id == user.Id).Select(fb => new FlightBooking
            {
                id = fb.id,
                user_id = fb.user_id,
                isBooked = fb.isBooked,
                paymentId = fb.paymentId,
                Flight = new Flight
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

        public Task<FlightBooking> UpdateAsync(FlightBooking entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
