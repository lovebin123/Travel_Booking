using System;
using api.DTO.Hotel;
using api.Helpers;
using api.Interfaces.Hotels;
using api.Mappers.Hotels;
using api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Hotels
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepo;
        public HotelController(IHotelRepository hotelRepo, UserManager<AppUser> userManager)
        {
            _hotelRepo = hotelRepo;
        }
        [HttpGet("getHotelsFromQuery")]
        public async Task<IActionResult> GetFromQuery([FromQuery] HotelQueryObject hotelQuery)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var hotels = await _hotelRepo.GetHotelsByQuery(hotelQuery);
            return Ok(hotels);
        }
        [HttpGet("searchByHotelName")]
        public async Task<IActionResult> SearchByHotelName(string name)
        {
            var hotels = await _hotelRepo.GetByHotelName(name);
            return Ok(hotels);
        }
        [HttpGet("getAllHotels")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAllHotels(int pageNumber=1,int pageSize=20)
        {
            var (hotels,totalCount) = await _hotelRepo.GetAllHotels(pageNumber,pageSize);
            return Ok(new {hotels,totalCount});
        }
        [HttpGet("getLocations")]
        public async Task<IActionResult> GetLocations()
        {
            var locations = _hotelRepo.GetLocations();
            return Ok(locations);
        }
        [HttpPost("createHotel")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> CreateHotel(HotelDTO hotelModal)
        {
            var hotel = await _hotelRepo.CreateHotel(hotelModal);
            return Ok(hotel);
        }
        [HttpPut("updateHotel")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> UpdatHotel(int id, HotelDTO hotelDTO)
        {
            var hotel = await _hotelRepo.UpdateHotel(id, hotelDTO);
            return Ok(hotel);
        }
        [HttpGet("getById")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var hotel = await _hotelRepo.GetById(id);
            return Ok(hotel);
        }
        [HttpDelete("deleteHotel")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotelRepo.DeleteHotel(id);
            return NoContent();
        }
    }
}
