using System;
using api.Extensions;
using api.Interfaces.Hotels;
using api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.v1.Hotels
{
    [ApiController]
    [Route("api/hotelPayement")]
    public class HotelPaymentController : ControllerBase
    {
        private readonly IHotelPaymentRepository _hotelPaymentRepository;
        private readonly UserManager<AppUser> _userManager;
        public HotelPaymentController(IHotelPaymentRepository hotelPaymentRepository, UserManager<AppUser> userManager)
        {
            _hotelPaymentRepository = hotelPaymentRepository;
            _userManager = userManager;
        }
        [HttpGet("getLastPayment")]
        public async Task<IActionResult> GetLastPayment(string sessionId)
        {
            var payment = await _hotelPaymentRepository.GetLastPayment(sessionId);
            return Ok(payment);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("getAllPayments")]
        public async Task<IActionResult> GetAllPayments()
        {
            var userName = User.GetFirstName();
            if (userName == null)
                return BadRequest("User name not found");
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return BadRequest("User not found");
            var payements = await _hotelPaymentRepository.GetHotelPayments(user);
            return Ok(payements);
        }
        [HttpGet("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            var payement = await _hotelPaymentRepository.GetById(id);
            return Ok(payement);
        }
    }
}
