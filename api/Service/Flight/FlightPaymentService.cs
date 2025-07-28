using api.Data;
using api.Models;
using api.Models.Flights;
using Microsoft.EntityFrameworkCore;

namespace api.Service.Flight
{
    public class FlightPaymentService : IFlightPaymentService
    {
        private readonly ApplicationDBContext _context;
        public FlightPaymentService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<FlightPayement>> GetAllPaymentsAsync(AppUser user)
        {
            return await _context.flightPayements
                .Where(fb => fb.flightBooking.user_id == user.Id)
                .Select(fb => new FlightPayement
                {
                    id = fb.id,
                    stripe_payement_intent_id = fb.stripe_payement_intent_id,
                    flightBooking = new FlightBooking
                    {
                        AppUser = new AppUser
                        {
                            FirstName = fb.flightBooking.AppUser.FirstName,
                            LastName = fb.flightBooking.AppUser.LastName
                        },
                        Flight = new api.Models.Flights.Flight
                        {
                            name = fb.flightBooking.Flight.name,
                            source = fb.flightBooking.Flight.source,
                            destination = fb.flightBooking.Flight.destination,
                            date_of_departure = fb.flightBooking.Flight.date_of_departure,
                            time_of_arrival = fb.flightBooking.Flight.time_of_arrival,
                            time_of_departure = fb.flightBooking.Flight.time_of_departure,
                        }
                    }
                }).ToListAsync();
        }

        public async Task<FlightPayement?> GetByPaymentIntentIdAsync(string id)
        {
            return await _context.flightPayements
                .Include(x => x.flightBooking.AppUser)
                .Include(x => x.flightBooking.Flight)
                .FirstOrDefaultAsync(x => x.stripe_payement_intent_id == id);
        }

        public async Task<FlightPayement?> GetLatestPaymentAsync(string sessionId)
        {
            var payment = await _context.flightPayements
                .Include(x => x.flightBooking.AppUser)
                .Include(x => x.flightBooking.Flight)
                .FirstOrDefaultAsync(x => x.sessionId == sessionId);

            if (payment == null) return null;

            var booking = await _context.FlightBookings.FindAsync(payment.FlightBookingId);
            var flight = await _context.Flights.FindAsync(payment.flightBooking.flight_id);

            if (flight?.no_of_seats > 0)
            {
                flight.no_of_seats -= int.Parse(booking.no_of_adults) + int.Parse(booking.no_of_children);
                _context.Update(flight);
                await _context.SaveChangesAsync();
            }

            return payment;
        }
    }
}
