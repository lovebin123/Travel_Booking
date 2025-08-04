using System;
using api.DTO.Car_Rental;
using api.Helpers;
using api.Models.Car_Rental;

namespace api.Interfaces.Car_Rentals
{
    public interface ICarRentalRepository
    {
        Task<List<CarRentalEntity>> GetCarRentalsByQuery(CarRentalQueryObjectDto queryObject);
        Task<(List<CarRentalEntity> carRentals, int totalCount)> GetAllCarRentals(int pageNumber, int pageSize);
        Task<List<string>> GetLocations();
        Task<CarRentalEntity> CreateCarRental(CarRentalDto carRentalDTO);
        Task<CarRentalEntity> UpdateCarRental(int id, CarRentalDto carRentalDTO);
        Task DeleteCarRental(int id);
        Task<List<CarRentalEntity>> SearchByCarName(string name);
        Task<CarRentalEntity> GetById(int id);
    }
}
