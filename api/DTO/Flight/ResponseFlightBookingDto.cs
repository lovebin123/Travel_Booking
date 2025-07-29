using api.DTO.Account;
using api.Models;

namespace api.DTO.Flight
{
    public class ResponseFlightBookingDto
    {
        public int id { get; set; }
        public string no_of_adults { get; set; }
        public string no_of_children { get; set; }
        public int amount { get; set; }
        public int flight_id { get; set; }
        public string user_id { get; set; }

        public int isBooked { get; set; }
        public string? paymentId { get; set; }
        public ResponseFlightDto Flight { get; set; }
        public AppUserDto AppUser { get; set; }
    }
}
