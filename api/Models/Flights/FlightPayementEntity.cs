using System;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.Models.Flights
{
    public class FlightPayementEntity
    {
        public int id { get; set; }
        public int FlightBookingId { get; set; }
        public string stripe_payement_intent_id { get; set; }
        public string sessionId { get; set; }
        public string payement_status { get; set; }
        public string card { get; set; }
        public double amount { get; set; }
        public FlightBookingEntity flightBooking { get; set; }

    }
}
