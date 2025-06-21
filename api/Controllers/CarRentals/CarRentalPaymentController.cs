using System;
using api.Extensions;
using api.Interfaces.Car_Rentals;
using api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.CarRentals
{
    [Route("api/carRentalPayment")]
    [ApiController]
    public class CarRentalPaymentController : ControllerBase
    {
        private readonly ICarRentalPaymentRepository _carRentalPaymentRepository;
        private readonly UserManager<AppUser> _userManager;
        public CarRentalPaymentController(ICarRentalPaymentRepository carRentalPaymentRepository, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _carRentalPaymentRepository = carRentalPaymentRepository;
        }
        [HttpGet("getLatestPayment")]
        public async Task<IActionResult> GetLatestPayment(string sessionId)
        {
            var payment = await _carRentalPaymentRepository.GetLatestCarRentalPayment(sessionId);
            return Ok(payment);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        [HttpGet("getAllPayments")]
        public async Task<IActionResult> GetAllPayments()
        {
            var userName = User.GetFirstName();
            if (userName == null)
                return BadRequest();
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return BadRequest();
            var payments = await _carRentalPaymentRepository.GetCarRentalPayments(user);
            return Ok(payments);
        }
        [HttpGet("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            var payment = await _carRentalPaymentRepository.GetById(id);
            return Ok(payment);
        }
    }
}
