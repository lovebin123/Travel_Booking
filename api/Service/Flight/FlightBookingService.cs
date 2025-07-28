using api.Extensions;
using api.Interfaces.Flights;
using api.Models;
using api.Models.Flights;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Service.Flight
{
    public class FlightBookingService : IFlightBookingService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IFlightBookingRepository _bookingRepository;

        public FlightBookingService(IFlightRepository flightRepository, IFlightBookingRepository bookingRepository)
        {
            _flightRepository = flightRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<FlightBooking> CreateBookingAsync(AppUser user, int flightId, int noOfAdults, int noOfChildren)
        {
            var flight = await _flightRepository.GetByIdAsync(flightId);
            if (flight == null) throw new Exception("Flight not found");

            var totalAmount = (noOfAdults + noOfChildren) * flight.price;

            var booking = new FlightBooking
            {
                user_id = user.Id,
                flight_id = flight.id,
                no_of_adults = noOfAdults.ToString(),
                no_of_children = noOfChildren.ToString(),
                amount = (int)totalAmount
            };

            return await _bookingRepository.CreateAsync(booking);
        }

        public async Task<List<FlightBooking>> GetUserBookingsAsync(AppUser user)
        {
            return await _bookingRepository.GetUserFlightBookings(user);
        }
    }
}
