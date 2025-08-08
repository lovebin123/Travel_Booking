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
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace api.Controllers.Flights
{
    [ApiController]
    [Route("api/v{version:apiVersion}/flights")]
    [ApiVersion("1.0")]

    public class FLightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly FlightMapper _mapper;
        public FLightController(IFlightService flightService,  FlightMapper mapper)
        {
            _flightService=flightService;
            _mapper = mapper;
        }
        [HttpGet("getByQuery")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(ResponseFlightDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFromQuery([FromQuery] QueryObjectDto query)
        {
            var flights = await _flightService.GetFlightsByQuery(query);
            Log.Information("Flights listed successfully based on query");
            return Ok(flights);
        }
        [HttpGet("searchByFlightName")]
        [ProducesResponseType(typeof(ResponseFlightDto), StatusCodes.Status200OK)]
        [Authorize(Roles ="Admin")]

        public async Task<IActionResult> SearchByFlightName([FromQuery] string name)
        {
            var flights = await _flightService.SearchByName(name);
            return Ok(flights);
        }
        [HttpGet("getAllFlights")]
        [ProducesResponseType(typeof(ResponseFlightDto), StatusCodes.Status200OK)]
        [MapToApiVersion("1.0")]
        [Authorize( Roles = "Admin")]

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
        [Authorize(Roles = "User")]
        [MapToApiVersion("1.0")]

        public async Task<IActionResult> GetSources()
        {
            var sources = await _flightService.GetSources();
            Console.WriteLine(sources);
            return Ok(sources);
        }
        [HttpGet("getDestinations")]
        [Authorize(Roles = "User")]
        [MapToApiVersion("1.0")]

        public async Task<IActionResult> GetDestinations()
        {
           
            Log.Information("Listed all destinations");
            var destinations =await  _flightService.GetDestinations();
            return Ok(destinations);
        }
        [HttpPost("createFlight")]
        [Authorize(Roles = "Admin")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(ResponseFlightDto), StatusCodes.Status200OK)]

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> CreateFlight(FlightDto flightModal)
        {

            var flights = await _flightService.CreateFlightAsync(flightModal);
            Log.Information("Created Flight Successfully");
            return Ok(flights);
        }
        [HttpGet("getById")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ResponseFlightDto), StatusCodes.Status200OK)]
        [MapToApiVersion("1.0")]

        public async Task<IActionResult> GetById(int id)
        {
            var flight = await _flightService.GetById(id);
            Log.Information("Fetched based on Id");
            return Ok(flight);
        }
        [HttpPut("updateFlight")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ResponseFlightDto), StatusCodes.Status200OK)]
        [MapToApiVersion("1.0")]


        public async Task<IActionResult> UpdateFlight(int id, FlightDto flightModal)
        {
            var flight = await _flightService.UpdateFlightAsync(id, flightModal);
            Log.Information("Updated Flight Successfully");
            return Ok(flight);
        }
        [HttpDelete("deleteFlight")]
        [Authorize(Roles = "Admin")]
        [MapToApiVersion("1.0")]

        public async Task<IActionResult> DeleteFlight(int id)
        {
             await _flightService.DeleteFlightAsync(id);
            Log.Information("Deleted flight Successfully");
            return NoContent();
        }

    }
}
