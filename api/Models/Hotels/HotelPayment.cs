using System;

namespace api.Models.Hotels
{
    public class HotelPayment
    {
        public int Id { get; set; }
        public string stripe_payement_intent_id { get; set; }
        public string sessionId { get; set; }
        public int bookingId { get; set; }
        public double amount { get; set; }
        public string card { get; set; }
        public string status { get; set; }
        public string booking_date { get; set; }
        public string booking_time { get; set; }
       public HotelBooking hotelBooking { get; set; }

    }
}
