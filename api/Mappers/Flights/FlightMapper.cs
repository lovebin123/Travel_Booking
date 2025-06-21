using System;
using api.DTO.Flight;
using api.Models.Flights;

namespace api.Mappers
{
    public static class FlightMapper
    {
        public static FlightDTO ToFlightDTO(this Flight flightModel)
        {
            return new FlightDTO
            {
                name=flightModel.name,
                price=flightModel.price,
                source=flightModel.source,
                destination=flightModel.destination,
                time_of_arrival = flightModel.time_of_arrival,
                time_of_departure=flightModel.time_of_departure,
                date_of_departure=flightModel.date_of_departure,
                seatType=flightModel.seatType,
            };
        }
    }
}
