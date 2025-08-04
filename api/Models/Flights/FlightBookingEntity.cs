using System;
using System.ComponentModel.DataAnnotations;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.Models.Flights
{
    public class FlightBookingEntity
    {
        public int id { get; set; }
        public string no_of_adults { get; set; }
        public string no_of_children { get; set; }
        public int amount { get; set; }
        public int flight_id { get; set; }
        public string user_id { get; set; }
        
        public int isBooked { get; set; }
        public string? paymentId { get; set; }
        public FlightEnitity Flight { get; set; }
        public AppUser AppUser { get; set; }
        public IEnumerable<FlightPayementEntity> flightPayements { get; set; } = new List<FlightPayementEntity>();
    }
}
