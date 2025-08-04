using System;
using api.DTO.Flight;
using api.Models.Flights;
using AutoMapper;
public class FlightMapper
{
    private readonly IMapper _mapper;
    public FlightMapper(IMapper mapper)
    {
        _mapper = mapper;

    }
    public FlightDto ConvertFlightToFlightDTO(FlightEnitity flight)
    {
        return _mapper.Map<FlightDto>(flight);
    }
    public FlightEnitity ConvertFlightDTOToFlight(FlightDto flightDTO)
    {
        return _mapper.Map<FlightEnitity>(flightDTO);
    }
}