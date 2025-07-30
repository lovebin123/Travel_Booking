using System;
using api.Models.Car_Rental;
using api.Models.Flights;
using api.Models.Hotels;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public IEnumerable<FlightBooking> FlightBookings { get; set; } = new List<FlightBooking>();
        public List<HotelBooking> HotelBookings { get; set; } = new List<HotelBooking>();
        public List<CarRentalBooking> CarRentalBookings { get; set; } = new List<CarRentalBooking>();
    }
}
