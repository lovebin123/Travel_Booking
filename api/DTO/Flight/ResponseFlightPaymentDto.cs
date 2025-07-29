namespace api.DTO.Flight
{
    public class ResponseFlightPaymentDto
    {
        public int id { get; set; }
        public int FlightBookingId { get; set; }
        public string stripe_payement_intent_id { get; set; }
        public string sessionId { get; set; }
        public string payement_status { get; set; }
        public string card { get; set; }
        public double amount { get; set; }
        public ResponseFlightBookingDto flightBooking { get; set; }
    }
}
