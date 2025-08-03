using System;
using api.Data;
using api.Interfaces.Car_Rentals;
using api.Models;
using api.Models.Car_Rental;
using Microsoft.EntityFrameworkCore;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613,8604
namespace api.Repository.Car_Rentals
{
    public class CarRentalBookingRepository : ICarRentalBookingRepository
    {
        private readonly ApplicationDBContext _context;
        public CarRentalBookingRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<CarRentalBooking> CreateCarRentalBooking(CarRentalBooking carRentalBooking)
        {
            await _context.CarRentalBookings.AddAsync(carRentalBooking);
            await _context.SaveChangesAsync();
            return carRentalBooking;
        }

        public async Task<CarRentalBooking> DeleteById(int id)
        {
            var booking = await _context.CarRentalBookings.FirstOrDefaultAsync(x => x.id == id);
            _context.CarRentalBookings.Remove(booking);
            _context.SaveChanges();
            return booking;
        }

        public async Task<CarRentalBooking?> GetById(int id)
        {
            var booking = await _context.CarRentalBookings.Include(x => x.user).Include(x => x.carRental).FirstOrDefaultAsync(x => x.id ==id);
            return booking;
        }

        public async Task<List<CarRentalBooking>> GetUserCarRentalBookings(AppUser user)
        {
            var bookings = await _context.CarRentalBookings.Where(x => x.user_id == user.Id).Select(x => new CarRentalBooking
            {
                amount = x.amount,
                bookedFromDate = x.bookedFromDate,
                bookedFromTime = x.bookedFromTime,
                bookedTillTime = x.bookedTillTime,
                bookedTillDate = x.bookedTillDate,
                id = x.id,
                isBooked = x.isBooked,
                paymentId = x.paymentId,
                carRental = new CarRental
                {
                    car_name = x.carRental.car_name,
                    drive_type = x.carRental.drive_type,
                    location = x.carRental.location,
                    price = x.carRental.price,
                    no_of_seats = x.carRental.no_of_seats,
                    rating = x.carRental.rating,
                    user_review = x.carRental.user_review
                }
            }).OrderByDescending(x => x.isBooked).ToListAsync();
            return bookings;
        }

    }
}