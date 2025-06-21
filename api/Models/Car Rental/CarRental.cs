using System;

namespace api.Models.Car_Rental
{
    public class CarRental
    {
        public int id { get; set; }
        public string car_name { get; set; }
        public string location { get; set; }
        public double rating { get; set; }
        public string user_review { get; set; }
        public decimal price { get; set; }
        public int no_of_seats { get; set; }
        public string drive_type { get; set; }
        public bool is_available { get; set; }
        public string AvailableFromDate { get; set; }
        public string AvailableUntilDate { get; set; }
        public string AvailableFromTime { get; set; }
        public string AvailableUntilTime { get; set; }
        public List<CarRentalBooking> CarRentalBookings { get; set; } = new List<CarRentalBooking>();

    }
}
