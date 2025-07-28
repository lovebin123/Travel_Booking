using System;
using api.Data;
using api.DTO.Flight;
using api.Helpers;
using api.Interfaces;
using api.Interfaces.Flights;
using api.Mappers;
using api.Models.Flights;
using api.Service;
using api.Service.Flight;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace api.Controllers
{
    [Route("api/flights")]
    [ApiController]
    public class FLightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly ILogger<Flight> _logger;
        private readonly FlightMapper _mapper;
        public FLightController(IFlightService flightService, ILogger<Flight> logger, FlightMapper mapper)
        {
            _logger = logger;
            _flightService=flightService;
            _mapper = mapper;
        }
        [HttpGet("getByQuery")]
        public async Task<IActionResult> GetFromQuery([FromQuery] QueryObject query)
        {
            var flights = await _flightService.GetFlightsByQuery(query);
            Log.Information("Flights listed successfully based on query");
            return Ok(flights);
        }
        [HttpGet("searchByFlightName")]
        public async Task<IActionResult> SearchByFlightName([FromQuery] string name)
        {
            var flights = await _flightService.SearchByName(name);
            _logger.LogInformation("Flights fetched successfully based on name");
            return Ok(flights);
        }
        [HttpGet("getAllFlights")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAllFlights(int pageNumber=1,int pageSize=20)
        {
            var (flights,totalCount) = await _flightService.GetPagedFlightsAsync(pageSize,pageNumber);
            Log.Information("Listed all flights");
            return Ok(new
            {
                flights,
                totalCount
               

            });
        }
        [HttpGet("getSources")]
        public async Task<IActionResult> GetSources()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var sources = _flightService.GetSources();
            Console.WriteLine(sources);
            return Ok(sources);
        }
        [HttpGet("getDestinations")]
        public async Task<IActionResult> GetDestinations()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Log.Information("Listed all destinations");
            var destinations = _flightService.GetDestinations();
            return Ok(destinations);
        }
        [HttpPost("createFlight")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> CreateFlight(FlightDTO flightModal)
        {

            var flights = await _flightService.CreateFlightAsync(flightModal);
            Log.Information("Created Flight Successfully");
            return Ok(flights);
        }
        [HttpGet("getById")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var flight = await _flightService.GetById(id);
            Log.Information("Fetched based on Id");
            return Ok(flight);
        }
        [HttpPut("updateFlight")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> UpdateFlight(int id, FlightDTO flightModal)
        {
            var flight = await _flightService.UpdateFlightAsync(id, flightModal);
            Log.Information("Updated Flight Successfully");
            return Ok(flight);
        }
        [HttpDelete("deleteFlight")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
             await _flightService.DeleteFlightAsync(id);
            Log.Information("Deleted flight Successfully");
            return NoContent();
        }

    }
}
