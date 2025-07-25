using System;

namespace api.DTO.Hotel
{
    public record HotelDTO
    {
        public string name { get; init; } = string.Empty;
        public string location { get; init; } = string.Empty;
        public double price { get; init; }
        public string user_review { get; init; } = string.Empty;
        public string rating { get; init; } = string.Empty;
        public int no_of_rooms_available { get; init; }
        public string bedroom_type { get; init; } = string.Empty;
        public int no_of_stars { get; init; }
        public string bed_type { get; init; } = string.Empty;
    }
}
