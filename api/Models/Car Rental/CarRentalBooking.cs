using System;

namespace api.Models.Car_Rental
{
    public class CarRentalBooking
    {
        public int id { get; set; }
        public int bookingId { get; set; }
        public string user_id { get; set; }
        public string bookedFromDate { get; set; }
        public string bookedTillDate { get; set; }
        public string bookedFromTime { get; set; }
        public string bookedTillTime { get; set; }
        public AppUser user { get; set; }
        public CarRental carRental { get; set; }
        public int isBooked { get; set; }
        public string? paymentId { get; set; }
        public double amount { get; set; }
        public List<CarRentalPayment> CarRentalPayments { get; set; } = new List<CarRentalPayment>();
    }
}
