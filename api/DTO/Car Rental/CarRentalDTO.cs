using System;

namespace api.DTO.Car_Rental
{
    public class CarRentalDTO
    {
        public string carName { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public double rating { get; set; }
        public string user_review { get; set; } = string.Empty;
        public decimal price { get; set; }
        public int no_of_seats { get; set; }
        public string drive_type { get; set; } = string.Empty;
        public bool is_available { get; set; }
        public string AvailableFromDate { get; set; } = string.Empty;
        public string AvailableUntilDate { get; set; } = string.Empty;
        public string AvailableFromTime { get; set; } = string.Empty;
        public string AvailableUntilTime { get; set; } = string.Empty;
    }
}
