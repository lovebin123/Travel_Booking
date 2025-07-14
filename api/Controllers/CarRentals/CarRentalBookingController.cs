using System;
using api.DTO.Car_Rental;
using api.Extensions;
using api.Interfaces.Car_Rentals;
using api.Models;
using api.Models.Car_Rental;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers.CarRentals
{
    [Route("api/carRentalBooking")]
    [ApiController]
    public class CarRentalBookingController : ControllerBase
    {
        private readonly ICarRentalBookingRepository _carRentalBookingRepository;
        private readonly ICarRentalRepository _carRentalRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICarRentalStripeRepository _carRentalStripeRepository;
        public CarRentalBookingController(ICarRentalBookingRepository carRentalBookingRepository, ICarRentalRepository carRentalRepository, UserManager<AppUser> userManager, ICarRentalStripeRepository carRentalStripeRepository)
        {
            _carRentalBookingRepository = carRentalBookingRepository;
            _carRentalStripeRepository = carRentalStripeRepository;
            _carRentalRepository = carRentalRepository;
            _userManager = userManager;
        }
        [HttpPost("createBooking")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="User")]
        public async Task<IActionResult> CreateCarRentalBooking(int id, CreateCarRentalBookingDTO carRentalBookingDTO)
        {
            var userName = User.GetFirstName();
            if (userName == null)
                return BadRequest();
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return BadRequest();
            var carRental = await _carRentalRepository.GetById(id);
            var booking = new CarRentalBooking
            {
                bookedFromDate = carRentalBookingDTO.pickupDate,
                bookedTillDate = carRentalBookingDTO.dropoffDate,
                bookedFromTime = carRentalBookingDTO.pickupTime,
                bookedTillTime = carRentalBookingDTO.dropoffTime,
                isBooked=0,
                amount = (double)(carRental.price * (carRentalBookingDTO.diff + 1)),
                user_id = user.Id,
                bookingId = carRental.id,
            };
            await _carRentalBookingRepository.CreateCarRentalBooking(booking);
            return Ok(booking);
        }
        [HttpGet("getUserBooking")]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> GetUserBookings()
        {
            var userName = User.GetFirstName();
            if (userName == null)
                return BadRequest();
            var user =await _userManager.FindByNameAsync(userName);
            if (user == null)
                return BadRequest();
            var bookings = await _carRentalBookingRepository.GetUserCarRentalBookings(user);
            return Ok(bookings);

        }
        [HttpPost("create-session")]
        public async Task<IActionResult> CreateCheckoutSession(int bookingId)
        {
            var session =await _carRentalStripeRepository.CreateCheckoutSession(bookingId);
            return Ok(session);
        }
        [HttpGet("success")]
        public async Task<Results<RedirectHttpResult, BadRequest>> CheckoutSuccess(string sessionId, int bookingId)
        {
            var booking = await _carRentalStripeRepository.GetSuccess(sessionId, bookingId);
            var payment = await _carRentalStripeRepository.CreateCarRentalPayment(booking);
            return TypedResults.Redirect($"http://localhost:4200/carRentalTicket/{payment.sessionId}", true, true); ;

        }

    }
}
