using api.DTO.Car_Rental;
using api.Helpers;

namespace api.Service.CarRental
{
    public interface ICarRentalService
    {
        Task<List<api.Models.Car_Rental.CarRental>> GetCarRentalsByQuery(CarRentalQueryObject queryObject);
        Task<(List<api.Models.Car_Rental.CarRental> carRentals, int totalCount)> GetAllCarRentals(int pageNumber, int pageSize);
        Task<List<string>> GetLocations();
        Task<api.Models.Car_Rental.CarRental> CreateCarRental(CarRentalDTO carRentalDTO);
        Task<api.Models.Car_Rental.CarRental> UpdateCarRental(int id, CarRentalDTO carRentalDTO);
        Task DeleteCarRental(int id);
        Task<List<api.Models.Car_Rental.CarRental>> SearchByCarName(string name);
        Task<api.Models.Car_Rental.CarRental> GetById(int id);
    }
}
