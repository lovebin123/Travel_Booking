using System;
using System.Threading.Tasks;
using api.Data;
using api.DTO.Hotel;
using api.Helpers;
using api.Interfaces.Hotels;
using api.Models.Hotels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613,8604
namespace api.Repository.Hotels
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDBContext _context;

        public HotelRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<HotelEntity> CreateHotel(HotelDTO hotelModel)
        {
            var hotel = new HotelEntity
            {
                bed_type = hotelModel.bed_type,
                bedroom_type = hotelModel.bedroom_type,
                location = hotelModel.location,
                name = hotelModel.name,
                no_of_rooms_available = hotelModel.no_of_rooms_available,
                no_of_stars = hotelModel.no_of_stars,
                price = hotelModel.price,
                rating = hotelModel.rating,
                user_review = hotelModel.user_review
            };
            await _context.hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task DeleteHotel(int id)
        {
            var hotel = await _context.hotels.FirstOrDefaultAsync(x => x.id == id);
            if (hotel != null)
            {
                _context.hotels.Remove(hotel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<(List<HotelEntity> hotels, int totalCount)> GetAllHotels(int pageNumber, int pageSize)
        {
            var totalCount = await _context.hotels.CountAsync();
            var hotels = await _context.hotels
                .OrderBy(f => f.id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (hotels, totalCount);
        }

        public async Task<HotelEntity> GetById(int id)
        {
            return await _context.hotels.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<HotelEntity>> GetHotelsByQuery(HotelQueryObjectDto query)
        {
            var hotels = _context.hotels.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.location))
            {
                hotels = hotels.Where(h => h.location.Contains(query.location));
            }

            return await hotels.OrderBy(h => h.price).ToListAsync();
        }

        public async Task<List<HotelEntity>> GetByHotelName(string name)
        {
            return await _context.hotels
                .Where(h => h.name.Contains(name))
                .ToListAsync();
        }

        public List<string> GetLocations()
        {
            return _context.hotels.Select(h => h.location).Distinct().ToList();
        }

        public async Task<HotelEntity> UpdateHotel(int id, HotelDTO hotelDTO)
        {
            var hotel = await _context.hotels.FirstOrDefaultAsync(x => x.id == id);
            if (hotel == null) return null;

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
