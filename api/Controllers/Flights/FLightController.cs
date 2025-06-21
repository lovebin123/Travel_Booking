using System;
using api.Data;
using api.DTO.Flight;
using api.Helpers;
using api.Interfaces;
using api.Interfaces.Flights;
using api.Mappers;
using api.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/flights")]
    [ApiController]
    public class FLightController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IFlightRepository _flightRepo;
        private readonly StripeRepository _stripe;
        public FLightController(ApplicationDBContext context, IFlightRepository flightRepo)
        {
            _context = context;
            _flightRepo = flightRepo;
        }
        [HttpGet("getByQuery")]
        public async Task<IActionResult> GetFromQuery([FromQuery] QueryObject query)
        {
            Console.WriteLine(query.date_of_departure);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var flights = await _flightRepo.GetFlightsByQuery(query);
            return Ok(flights);
        }
        [HttpGet("getAllFlights")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await _flightRepo.GetAllFlights();
            return Ok(flights);
        }
        [HttpGet("getSources")]
        public async Task<IActionResult> GetSources()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var sources = _flightRepo.GetSources();
            return Ok(sources);
        }
        [HttpGet("getDestinations")]
        public async Task<IActionResult> GetDestinations()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var destinations = _flightRepo.GetDestinations();
            return Ok(destinations);
        }
        [HttpPost("createFlight")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> CreateFlight(FlightDTO flightModal)
        {
            var flights = await _flightRepo.CreateFlight(flightModal);
            return Ok(flights);
        }
        [HttpGet("getById")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var flight = await _flightRepo.GetById(id);
            return Ok(flight);
        }
        [HttpPut("updateFlight")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> UpdateFlight(int id, FlightDTO flightModal)
        {
            var flight = await _flightRepo.UpdateFlight(id, flightModal);
            return Ok(flight);
        }
        [HttpDelete("deleteFlight")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
             await _flightRepo.DeleteById(id);
            return NoContent();
        }

    }
}
