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

        public Task<List<api.Models.Car_Rental.CarRentalEntity>> GetCarRentalsByQuery(CarRentalQueryObjectDto queryObject) =>
            _repo.GetCarRentalsByQuery(queryObject);

        public Task<(List<api.Models.Car_Rental.CarRentalEntity> carRentals, int totalCount)> GetAllCarRentals(int pageNumber, int pageSize) =>
            _repo.GetAllCarRentals(pageSize, pageNumber);

        public Task<List<string>> GetLocations() => _repo.GetLocations();

        public Task<api.Models.Car_Rental.CarRentalEntity> CreateCarRental(CarRentalDto carRentalDTO) => _repo.CreateCarRental(carRentalDTO);

        public Task<api.Models.Car_Rental.CarRentalEntity> UpdateCarRental(int id, CarRentalDto carRentalDTO) => _repo.UpdateCarRental(id, carRentalDTO);

        public Task DeleteCarRental(int id) => _repo.DeleteCarRental(id);

        public Task<List<api.Models.Car_Rental.CarRentalEntity>> SearchByCarName(string name) => _repo.SearchByCarName(name);

        public Task<api.Models.Car_Rental.CarRentalEntity> GetById(int id) => _repo.GetById(id);
    }
}
