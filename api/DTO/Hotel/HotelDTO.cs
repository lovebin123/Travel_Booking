using System;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.DTO.Hotel
{
    public class HotelDTO
    {
        public string name { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public double price { get; set; }
        public string user_review { get; set; } = string.Empty;
        public string rating { get; set; } = string.Empty;
        public int no_of_rooms_available { get; set; }
        public string bedroom_type { get; set; } = string.Empty;
        public int no_of_stars { get; set; }
        public string bed_type { get; set; } = string.Empty;
    }
}
