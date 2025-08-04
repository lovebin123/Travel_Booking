using api.Models.Flights;
using System.ComponentModel.DataAnnotations;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.DTO.Flight
{
    public record ResponseFlightDto
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
        public IEnumerable<FlightBookingEntity> FlightBookings { get; set; } = new List<FlightBookingEntity>();

    }
}
