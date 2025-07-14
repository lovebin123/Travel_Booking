using System;

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
