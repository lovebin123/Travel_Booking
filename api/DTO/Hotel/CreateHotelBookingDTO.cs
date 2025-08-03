using System;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.DTO.Hotel
{
    public class CreateHotelBookingDTO
    {
        public string no_of_rooms { get; set; }
        public string no_of_adults { get; set; }
        public string no_of_children { get; set; }
        public string check_in_date { get; set; }
        public string check_out_date { get; set; }
    }
}
