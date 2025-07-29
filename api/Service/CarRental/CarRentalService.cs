using api.DTO.Car_Rental;
using api.Helpers;
using api.Interfaces.Car_Rentals;

namespace api.Service.CarRental
{
    public class CarRentalService:ICarRentalService
    {
        private readonly ICarRentalRepository _repo;

        public CarRentalService(ICarRentalRepository repo)
        {
            _repo = repo;
        }

        public Task<List<api.Models.Car_Rental.CarRental>> GetCarRentalsByQuery(CarRentalQueryObject queryObject) =>
            _repo.GetCarRentalsByQuery(queryObject);

        public Task<(List<api.Models.Car_Rental.CarRental> carRentals, int totalCount)> GetAllCarRentals(int pageNumber, int pageSize) =>
            _repo.GetAllCarRentals(pageSize, pageNumber);

        public Task<List<string>> GetLocations() => _repo.GetLocations();

        public Task<api.Models.Car_Rental.CarRental> CreateCarRental(CarRentalDTO carRentalDTO) => _repo.CreateCarRental(carRentalDTO);

        public Task<api.Models.Car_Rental.CarRental> UpdateCarRental(int id, CarRentalDTO carRentalDTO) => _repo.UpdateCarRental(id, carRentalDTO);

        public Task DeleteCarRental(int id) => _repo.DeleteCarRental(id);

        public Task<List<api.Models.Car_Rental.CarRental>> SearchByCarName(string name) => _repo.SearchByCarName(name);

        public Task<api.Models.Car_Rental.CarRental> GetById(int id) => _repo.GetById(id);
    }
}
