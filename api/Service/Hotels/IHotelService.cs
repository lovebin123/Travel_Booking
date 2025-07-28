using api.DTO.Hotel;
using api.Helpers;
using api.Models.Hotels;

namespace api.Service.Hotels
{
    public interface IHotelService
    {
        Task<Hotel> CreateHotel(HotelDTO hotelModel);
        Task DeleteHotel(int id);
        Task<(List<Hotel> hotels, int totalCount)> GetAllHotels(int pageSize, int pageNumber);
        Task<Hotel> GetById(int id);
        Task<List<Hotel>> GetHotelsByQuery(HotelQueryObject query);
        Task<List<Hotel>> GetByHotelName(string name);
        List<string> GetLocations();
        Task<Hotel> UpdateHotel(int id, HotelDTO hotelDTO);
    }
}
