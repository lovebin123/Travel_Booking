using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models.Flights
{
    public class FlightBooking
    {
        public int id { get; set; }
        public string no_of_adults { get; set; }
        public string no_of_children { get; set; }
        public int amount { get; set; }
        public int flight_id { get; set; }
        public string user_id { get; set; }
        
        public int isBooked { get; set; }
        public string? paymentId { get; set; }
        public Flight Flight { get; set; }
        public AppUser AppUser { get; set; }
        public List<FlightPayement> flightPayements { get; set; } = new List<FlightPayement>();
    }
}
