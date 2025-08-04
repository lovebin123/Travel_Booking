using System;
using api.DTO.Hotel;
using api.Helpers;
using api.Models.Hotels;

namespace api.Interfaces.Hotels
{
    public interface IHotelRepository
    {
        List<string> GetLocations();
        Task<HotelEntity> GetById(int id);
        Task<List<HotelEntity>> GetHotelsByQuery(HotelQueryObjectDto hotelQueryObject);
        Task<List<HotelEntity>> GetByHotelName(string name);
        Task<(List<HotelEntity> hotels, int totalCount)> GetAllHotels(int pageNumber,int pageSize);
        Task<HotelEntity> CreateHotel(HotelDTO hotelModel);
        Task<HotelEntity> UpdateHotel(int id, HotelDTO hotelDTO);
        Task DeleteHotel(int id);
    }
}
