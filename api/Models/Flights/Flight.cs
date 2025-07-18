using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models.Flights
{
    public class Flight
    {
        public int id { get; set; }
        [MaxLength(255)]
        public string? name { get; set; }
        [Range(1000,3000)]
        public double price { get; set; }
        public string? source { get; set; }
        public string? destination { get; set; }
        public string? date_of_departure { get; set; }
        
        public string? time_of_departure { get; set; }
        public string? time_of_arrival { get; set; }
        public string? seatType { get; set; }
        public int no_of_seats { get; set; }
        public IEnumerable<FlightBooking> FlightBookings { get; set; } = new List<FlightBooking>();
    }
}
