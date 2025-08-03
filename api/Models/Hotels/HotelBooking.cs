using System;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.Models.Hotels
{
    public class HotelBooking
    {
        public int id { get; set; }
        public int hotel_id { get; set; }
        public string user_id { get; set; }
        public AppUser user { get; set; }
        public Hotel hotel { get; set; }
        public string check_in_date { get; set; }
        public string check_out_date { get; set; }
        public int no_of_adults { get; set; }
        public int no_of_children { get; set; }
        public int no_of_rooms { get; set; }
        public double price { get; set; }
        
        public int isBooked { get; set; }
        public string? paymentId { get; set; }
        public IEnumerable<HotelPayment> hotelPayments { get; set; } = new List<HotelPayment>(); 

    }
}
