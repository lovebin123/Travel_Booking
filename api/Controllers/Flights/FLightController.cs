using System;
using api.Data;
using api.DTO.Flight;
using api.Helpers;
using api.Interfaces;
using api.Interfaces.Flights;
using api.Mappers;
using api.Models.Flights;
using api.Service;
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
        private readonly ApplicationDBContext _context;
        private readonly IFlightRepository _flightRepo;
        private readonly FlightMapper _flightMapper;
        
        public FLightController(ApplicationDBContext context, IFlightRepository flightRepo,FlightMapper mapper)
        {
            _context = context;
            _flightMapper = mapper;
            _flightRepo = flightRepo;
        }
        [HttpGet("getByQuery")]
        public async Task<IActionResult> GetFromQuery([FromQuery] QueryObject query)
        {
            var flights = await _flightRepo.GetFlightsByQuery(query);
            Log.Information("Flights listed successfully based on query");
            return Ok(flights);
        }
        [HttpGet("searchByFlightName")]
        public async Task<IActionResult> SearchByFlightName([FromQuery] string name)
        {
            var flights = await _flightRepo.GetSearchFlights(name);
            return Ok(flights);
        }
        [HttpGet("getAllFlights")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAllFlights(int pageNumber=1,int pageSize=20)
        {
            var (flights,totalCount) = await _flightRepo.GetAllFlights(pageNumber,pageSize);
            Log.Information("Listed all flights");
            return Ok(new
            {
                flights,
                totalCount,
                pageNumber,
                pageSize

            });
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
            Log.Information("Listed all destinations");
            var destinations = _flightRepo.GetDestinations();
            return Ok(destinations);
        }
        [HttpPost("createFlight")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> CreateFlight(FlightDTO flightModal)
        {
           var flight= _flightMapper.ConvertFlightDTOToFlight(flightModal);
            var flights = await _flightRepo.AddAsync(flight);
            Log.Information("Created Flight Successfully");
            return Ok(flights);
        }
        [HttpGet("getById")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var flight = await _flightRepo.GetByIdAsync(id);
            Log.Information("Fetched based on Id");
            return Ok(flight);
        }
        [HttpPut("updateFlight")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> UpdateFlight(int id, FlightDTO flightModal)
        {
            var nFlight = _flightMapper.ConvertFlightDTOToFlight(flightModal);
            var flight = await _flightRepo.UpdateAsync( nFlight,id);
            Log.Information("Updated Flight Successfully");
            return Ok(flight);
        }
        [HttpDelete("deleteFlight")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
             await _flightRepo.DeleteAsync(id);
            Log.Information("Deleted flight Successfully");
            return NoContent();
        }

    }
}
