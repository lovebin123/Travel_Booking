using System;
using api.DTO.Hotel;
using api.Helpers;
using api.Models.Hotels;

namespace api.Interfaces.Hotels
{
    public interface IHotelRepository:IGenericRepository<Hotel>
    {
        List<string> GetLocations();
        Task<List<Hotel>> GetHotelsByQuery(HotelQueryObject hotelQueryObject);
        Task<List<Hotel>> GetByHotelName(string name);
        Task<(List<Hotel> hotels, int totalCount)> GetAllHotels(int pageNumber,int pageSize);
    
    }
}
