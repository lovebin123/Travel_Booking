using api.DTO.Account;
using api.DTO.Flight;
using api.Extensions;
using api.Interfaces;
using api.Interfaces.Flights;
using api.Models;
using api.Models.Flights;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Linq;

namespace api.Service.Flight
{
    public class FlightBookingService : IFlightBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FlightBookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseFlightBookingDto> CreateBookingAsync(AppUser user, int flightId, int noOfAdults, int noOfChildren)
        {
            var flight = await _unitOfWork.FlightRepository.GetByIdAsync(flightId);
            if (flight == null)
            {
                Log.Error("Flight not found");
                throw new Exception("Flight not found");
            }
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
            Log.Information("Created booking successfully");
            await _unitOfWork.CompleteAsync();
            var responseDto = new ResponseFlightBookingDto
            {
                amount = result.amount,
                flight_id = result.flight_id,
                AppUser = new DTO.Account.AppUserDto
                {
                    Email = result.AppUser.Email,
                    FirstName = result.AppUser.FirstName,
                    LastName = result.AppUser.LastName,
                    Id = result.AppUser.Id
                },
                isBooked = result.isBooked,
                no_of_adults = result.no_of_adults,
                id = result.id,
                no_of_children = result.no_of_children,
                paymentId = result.paymentId,
                Flight = new ResponseFlightDto
                {
                    date_of_departure = result.Flight.date_of_departure,
                    destination = result.Flight.destination,
                    id = result.Flight.id,
                    FlightBookings = result.Flight.FlightBookings.ToList(),
                    name = result.Flight.name,
                    no_of_seats = result.Flight.no_of_seats,
                    price = result.Flight.price,
                    seatType = result.Flight.seatType,
                    source = result.Flight.source,
                    time_of_arrival = result.Flight.time_of_arrival,
                    time_of_departure = result.Flight.time_of_departure
                },
                user_id = result.user_id
            };
            return responseDto;
        }

        public async Task<List<ResponseFlightBookingDto>>GetUserBookingsAsync(AppUser user)
        {
            var res = await _unitOfWork.FlightBookingRepository.GetUserFlightBookings(user);

            var responseDto = res.Select(result => new ResponseFlightBookingDto
            {
                amount = result.amount,
                flight_id = result.flight_id,
                AppUser = result.AppUser == null ? null : new AppUserDto
                {
                    Id =result.AppUser.Id,
                    FirstName = result.AppUser.FirstName,
                    LastName = result.AppUser.LastName,
                    Email = result.AppUser.Email,


                },
                isBooked = result.isBooked,
                no_of_adults = result.no_of_adults,
                id = result.id,
                no_of_children = result.no_of_children,
                paymentId = result.paymentId,
                Flight = result.Flight == null ? null : new ResponseFlightDto
                {
                    date_of_departure = result.Flight.date_of_departure,
                    destination = result.Flight.destination,
                    id = result.Flight.id,
                    FlightBookings = result.Flight.FlightBookings?.ToList() ?? new List<FlightBooking>(),
                    name = result.Flight.name,
                    no_of_seats = result.Flight.no_of_seats,
                    price = result.Flight.price,
                    seatType = result.Flight.seatType,
                    source = result.Flight.source,
                    time_of_arrival = result.Flight.time_of_arrival,
                    time_of_departure = result.Flight.time_of_departure
                },
                user_id = result.user_id
            }).ToList();

            return responseDto;
        }
    }
}
