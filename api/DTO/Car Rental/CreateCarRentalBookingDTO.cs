using System;

namespace api.DTO.Car_Rental
{
    public class CreateCarRentalBookingDTO
    {
        public string pickupDate { get; set; }
        public string dropoffDate { get; set; }
        public string pickupTime { get; set; }
        public string dropoffTime { get; set; }
        public int diff { get; set; }
    }
}
