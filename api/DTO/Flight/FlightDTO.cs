using System;

namespace api.DTO.Flight
{
    public record FlightDTO
    {
        public string name { get; init; }
        public double price { get; init; }
        public string source { get; init; }
        public string destination { get; init; }
        public string date_of_departure { get; init; }
        public string time_of_departure { get; init; }
        public string time_of_arrival { get; init; }
        public string seatType { get; init; }
        public int no_of_seats { get; init; }
    }
}
