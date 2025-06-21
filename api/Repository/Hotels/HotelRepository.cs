using System;
using System.Threading.Tasks;
using api.Data;
using api.DTO.Hotel;
using api.Helpers;
using api.Interfaces.Hotels;
using api.Models.Hotels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Hotels
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDBContext _context;
        public HotelRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Hotel> CreateHotel(HotelDTO hotelModel)
        {
            var hotel = new Hotel
            {
                bed_type = hotelModel.bed_type,
                bedroom_type = hotelModel.bedroom_type,
                location = hotelModel.location,
                name = hotelModel.name,
                no_of_rooms_available = hotelModel.no_of_rooms_available,
                no_of_stars = hotelModel.no_of_stars,
                price = hotelModel.price,
                rating = hotelModel.rating,
                user_review=hotelModel.user_review
            };
            await _context.AddAsync(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task DeleteHotel(int id)
        {
            var hotel = await _context.hotels.FirstOrDefaultAsync(x => x.id == id);
            _context.hotels.Remove(hotel);
            _context.SaveChanges();
            
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            var hotels = await _context.hotels.Select(x => new Hotel
            {
                bed_type = x.bed_type,
                bedroom_type = x.bedroom_type,
                location = x.location,
                name = x.name,
                no_of_rooms_available = x.no_of_rooms_available,
                no_of_stars = x.no_of_stars,
                price = x.price,
                rating = x.rating,
                id = x.id,
                user_review = x.user_review
            }).ToListAsync();
            return hotels;
        }

        public async Task<Hotel> GetById(int id)
        {
            var hotel = await _context.hotels.FirstOrDefaultAsync(x => x.id == id);
            return hotel;
        }

        public async Task<List<Hotel>> GetHotelsByQuery(HotelQueryObject query)
        {
            var hotels = _context.hotels.AsQueryable();
            if (!String.IsNullOrWhiteSpace(query.location))
            {
                hotels = hotels.Where(s => s.location.Contains(query.location));
            }
            return await hotels.OrderBy(x=>x.price).ToListAsync();
        }
        

        public List<string> GetLocations()
        {
            var locations = _context.hotels.Select(x => x.location).ToList();
            return locations;
        }

        public async Task<Hotel> UpdateHotel(int id, HotelDTO hotelDTO)
        {
            var hotel = await _context.hotels.FirstOrDefaultAsync(x => x.id == id);
            hotel.bed_type = hotelDTO.bed_type;
            hotel.name = hotelDTO.name;
            hotel.user_review = hotelDTO.user_review;
            hotel.bedroom_type = hotelDTO.bedroom_type;
            hotel.location = hotelDTO.location;
            hotel.no_of_rooms_available = hotelDTO.no_of_rooms_available;
            hotel.no_of_stars = hotelDTO.no_of_stars;
            hotel.price = hotelDTO.price;
            hotel.rating = hotelDTO.rating;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
