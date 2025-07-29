using api.Extensions;
using api.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public FlightBookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FlightBooking> CreateBookingAsync(AppUser user, int flightId, int noOfAdults, int noOfChildren)
        {
            var flight = await _unitOfWork.FlightRepository.GetByIdAsync(flightId);
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

            var result = await _unitOfWork.FlightBookingRepository.CreateAsync(booking);

            await _unitOfWork.CompleteAsync();

            return result;
        }

        public async Task<List<FlightBooking>> GetUserBookingsAsync(AppUser user)
        {
            return await _unitOfWork.FlightBookingRepository.GetUserFlightBookings(user);
        }
    }
}
