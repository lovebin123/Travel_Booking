using api.Validators;
using System;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.DTO.Flight
{
    public class FlightDTO
    {
        [SmartRequired]
        public string? name { get; set; }
        [SmartRequired]
        public double price { get; set; }
        [SmartRequired]

        public string? source { get; set; }
        [SmartRequired]

        public string? destination { get; set; }
        [SmartRequired]

        public string? date_of_departure { get; set; }
        [SmartRequired]

        public string? time_of_departure { get; set; }
        [SmartRequired]

        public string? time_of_arrival { get; set; }
        [SmartRequired]

        public string? seatType { get; set; }
        [SmartRequired]

        public int no_of_seats { get; set; }

    }
}
