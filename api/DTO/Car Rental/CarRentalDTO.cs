using System;

namespace api.DTO.Car_Rental
{
    public record CarRentalDTO
    {
        public string carName { get; init; } = string.Empty;
        public string location { get; init; } = string.Empty;
        public double rating { get; init; }
        public string user_review { get; init; } = string.Empty;
        public decimal price { get; init; }
        public int no_of_seats { get; init; }
        public string drive_type { get; init; } = string.Empty;
        public bool is_available { get; init; }
        public string AvailableFromDate { get; init; } = string.Empty;
        public string AvailableUntilDate { get; init; } = string.Empty;
        public string AvailableFromTime { get; init; } = string.Empty;
        public string AvailableUntilTime { get; init; } = string.Empty;
    }
}
