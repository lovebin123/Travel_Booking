using System;

namespace api.Models.Flights
{
    public class Flight
    {
        public int id { get; set; }
        public string? name { get; set; }
        public double price { get; set; }
        public string? source { get; set; }
        public string? destination { get; set; }
        public string? date_of_departure { get; set; }
        
        public string? time_of_departure { get; set; }
        public string? time_of_arrival { get; set; }
        public string? seatType { get; set; }
        public int no_of_seats { get; set; }
        public List<FlightBooking> FlightBookings { get; set; } = new List<FlightBooking>();
    }
}
