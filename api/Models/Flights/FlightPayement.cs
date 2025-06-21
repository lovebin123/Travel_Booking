using System;

namespace api.Models.Flights
{
    public class FlightPayement
    {
        public int id { get; set; }
        public int FlightBookingId { get; set; }
        public string stripe_payement_intent_id { get; set; }
        public string sessionId { get; set; }
        public string payement_status { get; set; }
        public string card { get; set; }
        public double amount { get; set; }
        public FlightBooking flightBooking { get; set; }

    }
}
