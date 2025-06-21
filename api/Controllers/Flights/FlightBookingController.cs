using System;
using api.Data;
using api.Extensions;
using api.Interfaces.Flights;
using api.Models;
using api.Models.Flights;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace api.Controllers.Flights
{
    [Route("api/flightBooking")]
    [ApiController]
    public class FlightBookingController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFlightRepository _flightRepository;
        private readonly IStripePayementRepository _stripe;
        private readonly ApplicationDBContext _context;
        private readonly IFlightBookingRepository _flightBookingRepository;
        public FlightBookingController(ApplicationDBContext context, UserManager<AppUser> userManager, IFlightRepository flightRepository, IFlightBookingRepository flightBookingRepository, IStripePayementRepository stripe)
        {
            _userManager = userManager;
            _flightBookingRepository = flightBookingRepository;
            _flightRepository = flightRepository;
            _stripe = stripe;
            _context = context;
        }
        [HttpPost("postBooking")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> CreateFlightBooking(int id, string no_of_adults1, string no_of_children11)
        {
            var userName = User.GetFirstName();
            var appUser = await _userManager.FindByNameAsync(userName);
            if (appUser == null)
                return BadRequest();
            var flight = await _flightRepository.GetByIdAsync(id);
            if (flight == null)
                return BadRequest();
            var userBooking = await _flightBookingRepository.GetUserFlightBookings(appUser);
            if (userBooking == null)
                return BadRequest();
            var flightBooking = new FlightBooking
            {
                user_id = appUser.Id,
                flight_id = flight.id,
                no_of_adults = no_of_adults1,
                no_of_children = no_of_children11,
                amount = (int)((Int32.Parse(no_of_adults1) + Int32.Parse(no_of_children11)) * flight.price),

            };
            await _flightBookingRepository.CreateAsync(flightBooking);
            return Ok(flightBooking);
        }
        [HttpGet("getBookings")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> GetUserFlightBookings()
        {
            var userName = User.GetFirstName();
            var appUser = await _userManager.FindByNameAsync(userName);
            if (appUser == null)
                return BadRequest();
            var userBooking = await _flightBookingRepository.GetUserFlightBookings(appUser);
            return Ok(userBooking);
        }
        [HttpPost("payement-session")]
        public async Task<IActionResult> CreateCheckoutSession(int id)
        {
            var session = await _stripe.CreateFlightBookingPaymentSession(id);
            return Ok(session);
        }
        [HttpGet("success")]
        public async Task<Results<RedirectHttpResult, BadRequest>> CheckOutSuccess([FromQuery(Name = "sessionId")] string sessionId, [FromQuery(Name = "booking_id")] int bookingId)
        {
            var payment = await _stripe.GetSuccess(sessionId, bookingId);
            var result = await _stripe.CreateFlightPayment(payment);
            return TypedResults.Redirect($"http://localhost:4200/flightTicket/{payment.sessionId}", true, true);
        }
    }
}
