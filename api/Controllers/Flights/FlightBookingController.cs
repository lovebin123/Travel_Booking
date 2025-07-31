using System;
using api.Data;
using api.Extensions;
using api.Interfaces.Flights;
using api.Models;
using api.Models.Flights;
using api.Service.Flight;
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
        private readonly IFlightBookingService _bookingService;
        private readonly IStripeService _stripeService;

        public FlightBookingController(UserManager<AppUser> userManager, IFlightBookingService bookingService, IStripeService stripeService)
        {
            _userManager = userManager;
            _bookingService = bookingService;
            _stripeService = stripeService;
        }

        [HttpPost("postBooking")]
        public async Task<IActionResult> CreateFlightBooking(int id, string no_of_adults1, string no_of_children11)
        {
            var userName = User.GetFirstName();
            var appUser = await _userManager.FindByNameAsync(userName);
            if (appUser == null) return BadRequest();

            var booking = await _bookingService.CreateBookingAsync(
                appUser,
                id,
                int.Parse(no_of_adults1),
                int.Parse(no_of_children11));

            return Ok(booking);
        }

        [HttpGet("getBookings")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserFlightBookings()
        {
            var userName = User.GetFirstName();
            var appUser = await _userManager.FindByNameAsync(userName);
            if (appUser == null) return BadRequest();

            var bookings = await _bookingService.GetUserBookingsAsync(appUser);
            return Ok(bookings);
        }

        [HttpPost("payement-session")]
        public async Task<IActionResult> CreateCheckoutSession(int id)
        {
            var session = await _stripeService.CreateFlightBookingPaymentSession(id);
            return Ok(session);
        }

        [HttpGet("success")]
        public async Task<Results<RedirectHttpResult, BadRequest>> CheckOutSuccess([FromQuery(Name = "sessionId")] string sessionId, [FromQuery(Name = "booking_id")] int bookingId)
        {
            var payment = await _stripeService.HandleSuccessfulPayment(sessionId, bookingId);
            return TypedResults.Redirect($"http://localhost:4200/flightTicket/{payment.sessionId}", true, true);
        }
    }
}
