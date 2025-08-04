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

        public async Task<List<FlightPayementEntity>> GetAllPayments(AppUser user)
        {
            return await _context.flightPayements
                .Where(fb => fb.flightBooking.user_id == user.Id)
                .Include(fb => fb.flightBooking.AppUser)
                .Include(fb => fb.flightBooking.Flight)
                .ToListAsync();
        }

        public async Task<FlightPayementEntity?> GetById(string intentId)
        {
            return await _context.flightPayements
                .Include(x => x.flightBooking.AppUser)
                .Include(x => x.flightBooking.Flight)
                .FirstOrDefaultAsync(x => x.stripe_payement_intent_id == intentId);
        }

        public async Task<FlightPayementEntity?> GetLatestPayment(string sessionId)
        {
            return await _context.flightPayements
                .Include(x => x.flightBooking.AppUser)
                .Include(x => x.flightBooking.Flight)
                .FirstOrDefaultAsync(x => x.sessionId == sessionId);
        }

        public async Task DeductFlightSeatsAsync(int bookingId)
        {
            var booking = await _context.FlightBookings.FindAsync(bookingId);
            if (booking == null) return;

            var flight = await _context.Flights.FindAsync(booking.flight_id);
            if (flight == null) return;

            int seatsToDeduct = int.Parse(booking.no_of_adults) + int.Parse(booking.no_of_children);

            if (flight.no_of_seats >= seatsToDeduct)
            {
                flight.no_of_seats -= seatsToDeduct;
                _context.Flights.Update(flight);
                await _context.SaveChangesAsync();
            }
        }
        #region

        public IQueryable<FlightPayementEntity> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public Task<FlightPayementEntity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(FlightPayementEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(FlightPayementEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(FlightPayementEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
