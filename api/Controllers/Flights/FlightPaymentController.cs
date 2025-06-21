using api.Extensions;
using api.Interfaces.Flights;
using api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers.Flights
{
    [Route("api/payments")]
    [ApiController]
    public class FlightPaymentController : ControllerBase
    {
        private readonly IFlightPaymentRepository _flightRepo;
        private readonly UserManager<AppUser> _userManager;

        public FlightPaymentController(IFlightPaymentRepository flightRepo, UserManager<AppUser> userManager)
        {
            _flightRepo = flightRepo;
            _userManager = userManager;
        }
        [HttpGet("getLatestPayment")]
        public async Task<IActionResult> GetLatest(string sessionId)
        {
            var payments = await _flightRepo.GetLatestPayment(sessionId);
            return Ok(payments);
        }
        [HttpGet("getAllPayments")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetPayments()
        {
            var userName = User.GetFirstName();
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return BadRequest("User does not exist");
            var payments = await _flightRepo.GetAllPayments(user);
            return Ok(payments);
        }
        [HttpGet("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            var payments = await _flightRepo.GetById(id);
            return Ok(payments);
        }

    }
}
