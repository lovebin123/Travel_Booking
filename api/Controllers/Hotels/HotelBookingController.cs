using System;
using api.DTO.Hotel;
using api.Extensions;
using api.Interfaces.Hotels;
using api.Models;
using api.Models.Hotels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace api.Controllers.Hotels
{
    [ApiController]
    [Route("api/hotelBooking")]
    public class HotelBookingController : ControllerBase
    {
        private readonly IHotelBookingRepository _hotelBookingRepo;
        private readonly IHotelRepository _hotelRepository;
        private readonly IHotelStripeRepository _hotelStripeRepository;
        private readonly UserManager<AppUser> _userManager;
        public HotelBookingController(IHotelBookingRepository hotelBookingRepo, IHotelRepository hotelRepository, UserManager<AppUser> userManager, IHotelStripeRepository hotelStripeRepository)
        {
            _hotelBookingRepo = hotelBookingRepo;
            _hotelRepository = hotelRepository;
            _userManager = userManager;
            _hotelStripeRepository = hotelStripeRepository;

        }
        [HttpPost("postBooking")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="User")]
        public async Task<IActionResult> CreateHotelBooking(int id, CreateHotelBookingDTO hotelBookingDTO)
        {
            var username = User.GetFirstName();
            if (username == null)
                return Unauthorized("User does not exist");
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return Unauthorized("User does not exist");
            var hotel = await _hotelRepository.GetById(id);
            
            if (hotel.price - Int32.Parse(hotelBookingDTO.no_of_rooms) < 0)
                return BadRequest();
            var booking = new HotelBooking
            {

                check_in_date = hotelBookingDTO.check_in_date,
                check_out_date = hotelBookingDTO.check_out_date,
                no_of_adults = Int32.Parse(hotelBookingDTO.no_of_adults),
                no_of_children = Int32.Parse(hotelBookingDTO.no_of_children),
                no_of_rooms = Int32.Parse(hotelBookingDTO.no_of_rooms),
                hotel_id = hotel.id,
                user_id = user.Id,
                price = (int)(hotel.price * Int32.Parse(hotelBookingDTO.no_of_rooms)),
            };
            await _hotelBookingRepo.CreateHotelBooking(booking);
            return Ok(booking);
        }
        [HttpPost("payment-session")]
        public async Task<IActionResult> CreateSession(int id)
        {
            var session = await _hotelStripeRepository.CreateCheckoutSession(id);
            return Ok(session);
        }
        [HttpGet("success")]
        public async Task<Results<RedirectHttpResult, BadRequest>> CheckoutSuccess([FromQuery(Name = "sessionId")] string sessionId, [FromQuery(Name = "booking_id")] int bookingId)
        {
            var payment = await _hotelStripeRepository.GetSuccess(sessionId, bookingId);
            var result = await _hotelStripeRepository.CreateHotelPayment(payment);
            return TypedResults.Redirect($"http://localhost:4200/hotelTicket/{payment.sessionId}", true, true); ;
        }
        [HttpGet("getUserBookings")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="User")]
        public async Task<IActionResult> GetUserBookings()
        {
            var userName = User.GetFirstName();
            if (userName == null)
                throw new Exception("User not found");
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return Unauthorized("user not found");
            var booking =await  _hotelBookingRepo.GetUserBookings(user);
            return Ok(booking);
        }

    }
}
