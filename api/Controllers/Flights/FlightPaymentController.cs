using api.DTO.Flight;
using api.Extensions;
using api.Interfaces.Flights;
using api.Models;
using api.Service.Flight;
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers.v1.Flights
{
    [Route("api/payments")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FlightPaymentController : ControllerBase
    {
        private readonly IFlightPaymentService _paymentService;
        private readonly UserManager<AppUser> _userManager;

        public FlightPaymentController(IFlightPaymentService paymentService, UserManager<AppUser> userManager)
        {
            _paymentService = paymentService;
            _userManager = userManager;
        }

        [HttpGet("getLatestPayment")]
        [ProducesResponseType(typeof(ResponseFlightPaymentDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLatest(string sessionId)
        {
            var payment = await _paymentService.GetLatestPaymentAsync(sessionId);
            if (payment == null) return NotFound("Payment not found");
            return Ok(payment);
        }

 

        [HttpGet("getById")]
        [ProducesResponseType(typeof(ResponseFlightPaymentDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(string id)
        {
            var payment = await _paymentService.GetByPaymentIntentIdAsync(id);
            if (payment == null) return NotFound("Payment not found");
            return Ok(payment);
        }
    }
}
