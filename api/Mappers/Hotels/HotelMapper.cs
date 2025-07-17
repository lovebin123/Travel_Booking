using System;
using api.DTO.Hotel;
using api.Models.Hotels;
using AutoMapper;

namespace api.Mappers.Hotels
{
    public class HotelMapper
    {
        private readonly IMapper _mapper;
        public HotelMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public HotelDTO HotelToHotelDTO(Hotel hotel)
        {
            return _mapper.Map<HotelDTO>(hotel);
        }
        public Hotel HotelDTOToHotel(HotelDTO hotelDTO)
        {
            return _mapper.Map<Hotel>(hotelDTO);
        }
    }
}
