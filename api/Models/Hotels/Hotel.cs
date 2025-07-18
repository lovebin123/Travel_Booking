using System;

namespace api.Models.Hotels
{
    public class Hotel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public double price { get; set; }
        public string user_review { get; set; }
        public string rating { get; set; }
        public int no_of_rooms_available { get; set; }
        public string bedroom_type { get; set; }
        public int no_of_stars { get; set; }
        public string bed_type { get; set; }

        public IEnumerable<HotelBooking> hotelBookings { get; set; }=new List<HotelBooking>();

    }
}
