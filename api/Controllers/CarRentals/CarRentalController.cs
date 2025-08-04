using System;
using api.DTO.Car_Rental;
using api.Helpers;
using api.Interfaces.Car_Rentals;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers.v1.CarRentals
{
    [Route("api/carRentals")]
    [ApiController]
    public class CarRentalController : ControllerBase
    {
        private readonly ICarRentalRepository _carRentalRepository;
        public CarRentalController(ICarRentalRepository carRentalRepository)
        {
            _carRentalRepository = carRentalRepository;
        }
        [HttpGet("getFromQuery")]
        public async Task<IActionResult> GetCarRentalsFromQuery([FromQuery] CarRentalQueryObjectDto queryObject)
        {
            var rentals = await _carRentalRepository.GetCarRentalsByQuery(queryObject);
            return Ok(rentals);
        }
        [HttpGet("getAllCarRentals")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAllCarRentals(int pageNumber, int pageSize)
        {
            var (carRentals, totalCount) = await _carRentalRepository.GetAllCarRentals(pageNumber, pageSize);
            return Ok(new { carRentals, totalCount });
        }
        [HttpGet("searchByCarName")]
        public async Task<IActionResult> SearchByCarName(string name)
        {
            var carRentals = await _carRentalRepository.SearchByCarName(name);
            return Ok(carRentals);
        }
        [HttpGet("getLocations")]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _carRentalRepository.GetLocations();
            return Ok(locations);
        }
        [HttpPost("createCarRental")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> CreateCarRental(CarRentalDto carRentalDTO)
        {
            var carRental = await _carRentalRepository.CreateCarRental(carRentalDTO);
            return Ok(carRental);
        }
        [HttpPut("updateCarRental")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> UpdateCarRental(int id, CarRentalDto carRentalDTO)
        {
            var carRental = await _carRentalRepository.UpdateCarRental(id, carRentalDTO);
            return Ok(carRental);
        }
        [HttpDelete("deleteCarRental")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> DeleteCarRental(int id)
        {
            await _carRentalRepository.DeleteCarRental(id);
            return NoContent();
        }
        [HttpGet("getById")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var carRental = await _carRentalRepository.GetById(id);
            return Ok(carRental);
        }
    }
}