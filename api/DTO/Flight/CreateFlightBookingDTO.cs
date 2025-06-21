using System;

namespace api.DTO.Flight
{
    public class CreateFlightBookingDTO
    {
        public string name { get; set; } = string.Empty;
        public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();
    }
}
