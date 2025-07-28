using api.DTO.Hotel;
using api.Helpers;
using api.Interfaces.Hotels;
using api.Models.Hotels;

namespace api.Service.Hotels
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<Hotel> CreateHotel(HotelDTO hotelModel) => await _hotelRepository.CreateHotel(hotelModel);

        public async Task DeleteHotel(int id) => await _hotelRepository.DeleteHotel(id);

        public async Task<(List<Hotel> hotels, int totalCount)> GetAllHotels(int pageSize, int pageNumber) =>
            await _hotelRepository.GetAllHotels(pageSize, pageNumber);

        public async Task<Hotel> GetById(int id) => await _hotelRepository.GetById(id);

        public async Task<List<Hotel>> GetHotelsByQuery(HotelQueryObject query) =>
            await _hotelRepository.GetHotelsByQuery(query);

        public async Task<List<Hotel>> GetByHotelName(string name) => await _hotelRepository.GetByHotelName(name);

        public List<string> GetLocations() => _hotelRepository.GetLocations();

        public async Task<Hotel> UpdateHotel(int id, HotelDTO hotelDTO) => await _hotelRepository.UpdateHotel(id, hotelDTO);
    }
}
