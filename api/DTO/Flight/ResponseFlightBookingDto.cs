using api.DTO.Account;
using api.Models;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.DTO.Flight
{
    public class ResponseFlightBookingDto
    {
        public int id { get; set; }
        public string? no_of_adults { get; set; }
        public string? no_of_children { get; set; }
        public int amount { get; set; }
        public int flight_id { get; set; }
        public string? user_id { get; set; }

        public int isBooked { get; set; }
        public string? paymentId { get; set; }
        public ResponseFlightDto? Flight { get; set; }
        public AppUserDto? AppUser { get; set; }

     
    }
}
