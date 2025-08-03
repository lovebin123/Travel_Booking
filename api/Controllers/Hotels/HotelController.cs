using api.DTO.Hotel;
using api.Helpers;
using api.Interfaces.Hotels;
using api.Mappers.Hotels;
using api.Models;
using api.Service.Hotels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace api.Controllers.v1.Hotels
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("getHotelsFromQuery")]
        public async Task<IActionResult> GetFromQuery([FromQuery] HotelQueryObject hotelQuery)
        {
            var hotels = await _hotelService.GetHotelsByQuery(hotelQuery);
            Log.Information("Fetched hotels based on query");
            return Ok(hotels);
        }

        [HttpGet("searchByHotelName")]
        public async Task<IActionResult> SearchByHotelName(string name)
        {
            var hotels = await _hotelService.GetByHotelName(name);
            Log.Information("Fetched hotels based on name");
            return Ok(hotels);
        }

        [HttpGet("getAllHotels")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAllHotels(int pageNumber = 1, int pageSize = 20)
        {
            var (hotels, totalCount) = await _hotelService.GetAllHotels(pageSize, pageNumber);
            return Ok(new { hotels, totalCount });
        }

        [HttpGet("getLocations")]
        public IActionResult GetLocations()
        {
            var locations = _hotelService.GetLocations();
            return Ok(locations);
        }

        [HttpPost("createHotel")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> CreateHotel(HotelDTO hotelModel)
        {
            var hotel = await _hotelService.CreateHotel(hotelModel);
            return Ok(hotel);
        }

        [HttpPut("updateHotel")]
        public async Task<IActionResult> UpdateHotel(int id, HotelDTO hotelDTO)
        {
            var hotel = await _hotelService.UpdateHotel(id, hotelDTO);
            return Ok(hotel);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var hotel = await _hotelService.GetById(id);
            return Ok(hotel);
        }

        [HttpDelete("deleteHotel")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotelService.DeleteHotel(id);
            return NoContent();
        }
    }
}

