using System;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613
namespace api.Models.Car_Rental
{
    public class CarRentalBookingEntity
    {
        public int id { get; set; }
        public int bookingId { get; set; }
        public string? user_id { get; set; }
        public string? bookedFromDate { get; set; }
        public string? bookedTillDate { get; set; }
        public string? bookedFromTime { get; set; }
        public string? bookedTillTime { get; set; }
        public AppUser? user { get; set; }
        public CarRentalEntity? carRental { get; set; }
        public int isBooked { get; set; }
        public string? paymentId { get; set; }
        public double amount { get; set; }
        public IEnumerable<CarRentalPaymentEntity> CarRentalPayments { get; set; } = new List<CarRentalPaymentEntity>();
    }
}
