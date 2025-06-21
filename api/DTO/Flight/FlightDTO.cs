using System;

namespace api.DTO.Flight
{
    public class FlightDTO
    {
        public string name { get; set; } = string.Empty;
        public double price { get; set; }
        public string source { get; set; } = string.Empty;
        public string destination { get; set; } = string.Empty;
        public string date_of_departure { get; set; } = string.Empty;
        public string time_of_departure { get; set; } = string.Empty;
        public string time_of_arrival { get; set; } = string.Empty;
        public string seatType { get; set; } = string.Empty;
                public int no_of_seats { get; set; }

    }
}
