using System;
using api.DTO.Car_Rental;
using api.Helpers;
using api.Models.Car_Rental;

namespace api.Interfaces.Car_Rentals
{
    public interface ICarRentalRepository
    {
        Task<List<CarRental>> GetCarRentalsByQuery(CarRentalQueryObject queryObject);
        Task<CarRental> GetById(int id);
        Task<List<CarRental>> GetAllCarRentals();
        Task<List<string>> GetLocations();
        Task<CarRental> CreateCarRental(CarRentalDTO carRentalDTO);
        Task<CarRental> UpdateCarRental(int id, CarRentalDTO carRentalDTO);
        Task DeleteCarRental(int id);
        
    }
}
