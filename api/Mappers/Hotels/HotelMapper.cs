using System;
using api.DTO.Hotel;
using api.Models.Hotels;

namespace api.Mappers.Hotels
{
    public static class HotelMapper
    {
        public static HotelDTO ToHotelDTO(this Hotel hotelModal)
        {
            return new HotelDTO
            {
                location = hotelModal.location,
                name = hotelModal.name,
                no_of_rooms_available = hotelModal.no_of_rooms_available,
                price = hotelModal.price,
                rating = hotelModal.rating,
                user_review = hotelModal.user_review,
                bedroom_type = hotelModal.bedroom_type,
                no_of_stars = hotelModal.no_of_stars,
                bed_type=hotelModal.bed_type

            };
        }
    }
}
