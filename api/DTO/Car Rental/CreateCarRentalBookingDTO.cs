using System;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.DTO.Car_Rental
{
    public class CreateCarRentalBookingDto
    {
        public string pickupDate { get; set; }
        public string dropoffDate { get; set; }
        public string pickupTime { get; set; }
        public string dropoffTime { get; set; }
        public int diff { get; set; }
    }
}
