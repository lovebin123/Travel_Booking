using api.DTO.Hotel;
using api.Helpers;
using api.Models.Hotels;

namespace api.Service.Hotels
{
    public interface IHotelService
    {
        Task<HotelEntity> CreateHotel(HotelDTO hotelModel);
        Task DeleteHotel(int id);
        Task<(List<HotelEntity> hotels, int totalCount)> GetAllHotels(int pageSize, int pageNumber);
        Task<HotelEntity> GetById(int id);
        Task<List<HotelEntity>> GetHotelsByQuery(HotelQueryObjectDto query);
        Task<List<HotelEntity>> GetByHotelName(string name);
        List<string> GetLocations();
        Task<HotelEntity> UpdateHotel(int id, HotelDTO hotelDTO);
    }
}
