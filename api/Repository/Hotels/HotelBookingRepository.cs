using System;
using api.Data;
using api.Interfaces.Hotels;
using api.Models;
using api.Models.Hotels;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Hotels
{
    public class HotelBookingRepository : IHotelBookingRepository
    {
        private readonly ApplicationDBContext _context;
        public HotelBookingRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<HotelBookingEnitity> CreateHotelBooking(HotelBookingEnitity hotelBooking)
        {
            await _context.HotelBookings.AddAsync(hotelBooking);
            await _context.SaveChangesAsync();
            return hotelBooking;
        }

        public async Task<HotelBookingEnitity> GetById(int bookingId)
        {
            var booking = await _context.HotelBookings.Include(x => x.user).Include(x => x.hotel).FirstOrDefaultAsync(x => x.id == bookingId);
            if (booking == null)
                throw new Exception("Booking not found");
            return booking;

        }
        public async Task<List<HotelBookingEnitity>>GetUserBookings(AppUser user)
        {
            var bookings = await _context.HotelBookings.Where(x => x.user_id == user.Id).Select(x => new HotelBookingEnitity
            {
                id = x.id,
                hotel_id = x.hotel_id,
                paymentId=x.paymentId,
                isBooked=x.isBooked,
                check_in_date=x.check_in_date,
                check_out_date=x.check_out_date,
                hotel = new HotelEntity
                {
                    name = x.hotel.name,
                    location = x.hotel.location,
                    bedroom_type = x.hotel.bedroom_type,
                    no_of_stars = x.hotel.no_of_stars,
                    bed_type = x.hotel.bed_type,
                    rating = x.hotel.rating,
                    user_review = x.hotel.user_review,
                },
                price = x.price
            }).OrderByDescending(x=>x.isBooked).ToListAsync();
            return bookings;
        }
    }
}
