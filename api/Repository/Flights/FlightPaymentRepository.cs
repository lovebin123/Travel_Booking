using System;
using api.Data;
using api.Interfaces.Flights;
using api.Models;
using api.Models.Flights;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Flights
{
    public class FlightPaymentRepository : IFlightPaymentRepository
    {
        private readonly ApplicationDBContext _context;
        public FlightPaymentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<FlightPayement>> GetAllPayments(AppUser user)
        {
            var payments = await _context.flightPayements.Where(fb => fb.flightBooking.user_id == user.Id).Select(fb => new FlightPayement
            {
                id=fb.id,
                stripe_payement_intent_id =fb.stripe_payement_intent_id,
                flightBooking = new FlightBooking
                {
                    AppUser=new AppUser
                    {
                        FirstName = fb.flightBooking.AppUser.FirstName,
                        LastName=fb.flightBooking.AppUser.LastName
                    },
                    Flight = new Flight
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
            return payments;
        }

        public async Task<FlightPayement> GetById(string id)
        {
            var payments = await _context.flightPayements.Include(x => x.flightBooking.AppUser).Include(x => x.flightBooking.Flight).FirstOrDefaultAsync(x=>string.Compare(x.stripe_payement_intent_id,id)==0);
            return payments;
        }

        public async Task<FlightPayement?> GetLatestPayment(string sessionId)
        {
            var payments = await _context.flightPayements.Include(x=>x.flightBooking.AppUser).Include(x=>x.flightBooking.Flight).Where(x=>string.Compare(x.sessionId,sessionId)==0).FirstOrDefaultAsync();
            var bookings = await _context.FlightBookings.FindAsync(payments.FlightBookingId);
            var flights = await _context.Flights.FindAsync(payments.flightBooking.flight_id);
            if (flights.no_of_seats != 0)
            {
                flights.no_of_seats -= Int32.Parse(bookings.no_of_adults) + Int32.Parse(bookings.no_of_children);
                _context.Update(flights);
            }
            _context.SaveChanges();
            return payments;
        }
    
    }
}
