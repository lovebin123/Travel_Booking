using System;
using api.Data;
using api.DTO.Car_Rental;
using api.Helpers;
using api.Interfaces.Car_Rentals;
using api.Models.Car_Rental;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Car_Rentals
{

    public class CarRentalRepository : ICarRentalRepository
    {
        private readonly ApplicationDBContext _context;
        public CarRentalRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<CarRental>> GetCarRentalsByQuery(CarRentalQueryObject queryObject)
        {
            var rentals = _context.CarRentals.AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryObject.location))
                rentals = rentals.Where(x => x.location == queryObject.location);
            if (queryObject.AvailableFromDate != default && queryObject.AvailableUntilDate != default)
            {
                rentals = rentals.Where(x => string.Compare(queryObject.AvailableFromDate, x.AvailableFromDate) >= 0 && string.Compare(x.AvailableUntilDate, queryObject.AvailableFromDate) >= 0);
            }
            if (!string.IsNullOrWhiteSpace(queryObject.AvailableFromTime) && !string.IsNullOrWhiteSpace(queryObject.AvailableUntilTime))
            {
                rentals = rentals.Where(x => String.Compare(queryObject.AvailableFromTime, x.AvailableFromTime) >= 0 && String.Compare(x.AvailableUntilTime, queryObject.AvailableFromTime) >= 0);
            }
            return await rentals.OrderBy(x => x.price).ToListAsync();
        }

        public async Task<CarRental> GetById(int id)
        {
            var rental = await _context.CarRentals.FirstOrDefaultAsync(x => x.id == id);
            return rental;
        }

        public async Task<(List<CarRental> carRentals, int totalCount)> GetAllCarRentals(int pageSize, int pageNumber)
        {
            var carRentals1 = await _context.CarRentals.Select(x => new CarRental
            {
                AvailableFromDate = x.AvailableFromDate,
                AvailableFromTime = x.AvailableFromTime,
                AvailableUntilDate = x.AvailableUntilDate,
                AvailableUntilTime = x.AvailableUntilTime,
                car_name = x.car_name,
                drive_type = x.drive_type,
                id = x.id,
                is_available = x.is_available,
                location = x.location,
                no_of_seats = x.no_of_seats,
                price = x.price,
                rating = x.rating,
                user_review = x.user_review,
            }).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var totalCount = await _context.CarRentals.CountAsync();
            return (carRentals1, totalCount);
        }

        public async Task<List<string>> GetLocations()
        {
            var locations = await _context.CarRentals.Select(x => x.location).ToListAsync();
            return locations;
        }

        public async Task<CarRental> CreateCarRental(CarRentalDTO carRentalDTO)
        {
            var carRental = new CarRental
            {
                AvailableFromDate = carRentalDTO.AvailableFromDate,
                AvailableFromTime = carRentalDTO.AvailableFromTime,
                AvailableUntilDate = carRentalDTO.AvailableUntilDate,
                AvailableUntilTime = carRentalDTO.AvailableUntilTime,
                car_name = carRentalDTO.carName,
                drive_type = carRentalDTO.drive_type,
                is_available = carRentalDTO.is_available,
                location = carRentalDTO.location,
                no_of_seats = carRentalDTO.no_of_seats,
                price = carRentalDTO.price,
                rating = carRentalDTO.rating,
                user_review = carRentalDTO.user_review
            };
            await _context.CarRentals.AddAsync(carRental);
            await _context.SaveChangesAsync();
            return carRental;
        }

        public async Task<CarRental> UpdateCarRental(int id, CarRentalDTO carRentalDTO)
        {
            Console.WriteLine(carRentalDTO);
            var carRental = await _context.CarRentals.FirstOrDefaultAsync(x => x.id == id);
            carRental.AvailableFromDate = carRentalDTO.AvailableFromDate;
            carRental.AvailableFromTime = carRentalDTO.AvailableFromTime;
            carRental.AvailableUntilDate = carRentalDTO.AvailableUntilDate;
            carRental.AvailableUntilTime = carRentalDTO.AvailableUntilTime;
            carRental.car_name = carRentalDTO.carName;
            carRental.drive_type = carRentalDTO.drive_type;
            carRental.is_available = carRentalDTO.is_available;
            carRental.location = carRentalDTO.location;
            carRental.no_of_seats = carRentalDTO.no_of_seats;
            carRental.price = carRentalDTO.price;
            carRental.rating = carRentalDTO.rating;
            await _context.SaveChangesAsync();
            return carRental;
        }

        public async Task DeleteCarRental(int id)
        {
            var carRental = await _context.CarRentals.FirstOrDefaultAsync(x => x.id == id);
            _context.CarRentals.Remove(carRental);
            _context.SaveChanges();

        }

        public async Task<List<CarRental>> SearchByCarName(string name)
        {
            var carRentals = _context.CarRentals.AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                carRentals = carRentals.Where(x => x.car_name.Contains(name));
            }
            return await carRentals.ToListAsync();
        }
    }
}