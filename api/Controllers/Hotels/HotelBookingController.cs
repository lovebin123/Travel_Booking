using System;
using api.DTO.Hotel;
using api.Extensions;
using api.Interfaces.Hotels;
using api.Models;
using api.Models.Hotels;
using api.Service.Hotels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace api.Controllers.v1.Hotels
{
     [ApiController]
    [Route("api/hotelBooking")]
    public class HotelBookingController : ControllerBase
    {
        private readonly IHotelBookingService _hotelBookingService;
        private readonly UserManager<AppUser> _userManager;

        public HotelBookingController(
            IHotelBookingService hotelBookingService,
            UserManager<AppUser> userManager)
        {
            _hotelBookingService = hotelBookingService;
            _userManager = userManager;
        }

        [HttpPost("postBooking")]
        public async Task<IActionResult> CreateHotelBooking(int id, CreateHotelBookingDTO dto)
        {
            var username = User.GetFirstName();
            if (username == null)
                return Unauthorized("User does not exist");

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return Unauthorized("User does not exist");

            var hotel = await _hotelBookingService.GetHotelById(id);
            if (hotel.price - int.Parse(dto.no_of_rooms) < 0)
                return BadRequest("Not enough room capacity");
            Console.WriteLine(hotel);
            var booking = new HotelBookingEnitity
            {
                check_in_date = dto.check_in_date,
                check_out_date = dto.check_out_date,
                no_of_adults = int.Parse(dto.no_of_adults),
                no_of_children = int.Parse(dto.no_of_children),
                no_of_rooms = int.Parse(dto.no_of_rooms),
                hotel_id = hotel.id,
                user_id = user.Id,
                price = hotel.price * int.Parse(dto.no_of_rooms),
            };

            await _hotelBookingService.CreateHotelBooking(booking);
            return Ok(booking);
        }

        [HttpPost("payment-session")]
        public async Task<IActionResult> CreateSession(int id)
        {
            var session = await _hotelBookingService.CreateStripeSession(id);
            return Ok(session);
        }

        [HttpGet("success")]
        public async Task<Results<RedirectHttpResult, BadRequest>> CheckoutSuccess(
            [FromQuery(Name = "sessionId")] string sessionId,
            [FromQuery(Name = "booking_id")] int bookingId)
        {
            var result = await _hotelBookingService.HandleStripeSuccess(sessionId, bookingId);
            return TypedResults.Redirect($"http://localhost:4200/dashboard/hotelTicket/{sessionId}", true, true);
        }

        [HttpGet("getUserBookings")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> GetUserBookings()
        {
            var username = User.GetFirstName();
            if (username == null)
                return Unauthorized("User not found");

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return Unauthorized("User not found");

            var bookings = await _hotelBookingService.GetUserBookings(user);
            return Ok(bookings);
        }
        [HttpDelete("deleteById")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult>DeleteById(int id)
        {
           await _hotelBookingService.DeleteById(id);
            
            return NoContent();
        }
    }
}
