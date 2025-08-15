using System;
using api.Models.Car_Rental;
using api.Models.Flights;
using api.Models.Hotels;
using Microsoft.AspNetCore.Identity;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public List<FlightBookingEntity> FlightBookings { get; set; } = new List<FlightBookingEntity>();
        public List<HotelBookingEnitity> HotelBookings { get; set; } = new List<HotelBookingEnitity>();
        public List<CarRentalBookingEntity> CarRentalBookings { get; set; } = new List<CarRentalBookingEntity>();
    }
}
