using System;
using api.DTO.Hotel;
using api.Helpers;
using api.Models.Hotels;

namespace api.Interfaces.Hotels
{
    public interface IHotelRepository
    {
        List<string> GetLocations();
        Task<Hotel> GetById(int id);
        Task<List<Hotel>> GetHotelsByQuery(HotelQueryObject hotelQueryObject);
        Task<List<Hotel>> GetByHotelName(string name);
        Task<(List<Hotel> hotels, int totalCount)> GetAllHotels(int pageNumber,int pageSize);
        Task<Hotel> CreateHotel(HotelDTO hotelModel);
        Task<Hotel> UpdateHotel(int id, HotelDTO hotelDTO);
        Task DeleteHotel(int id);
    }
}
