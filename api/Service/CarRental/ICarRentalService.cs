using api.DTO.Car_Rental;
using api.Helpers;

namespace api.Service.CarRental
{
    public interface ICarRentalService
    {
        Task<List<api.Models.Car_Rental.CarRentalEntity>> GetCarRentalsByQuery(CarRentalQueryObjectDto queryObject);
        Task<(List<api.Models.Car_Rental.CarRentalEntity> carRentals, int totalCount)> GetAllCarRentals(int pageNumber, int pageSize);
        Task<List<string>> GetLocations();
        Task<api.Models.Car_Rental.CarRentalEntity> CreateCarRental(CarRentalDto carRentalDTO);
        Task<api.Models.Car_Rental.CarRentalEntity> UpdateCarRental(int id, CarRentalDto carRentalDTO);
        Task DeleteCarRental(int id);
        Task<List<api.Models.Car_Rental.CarRentalEntity>> SearchByCarName(string name);
        Task<api.Models.Car_Rental.CarRentalEntity> GetById(int id);
    }
}
