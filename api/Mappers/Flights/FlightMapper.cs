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
    public FlightDTO ConvertFlightToFlightDTO(Flight flight)
    {
        return _mapper.Map<FlightDTO>(flight);
    }
    public Flight ConvertFlightDTOToFlight(FlightDTO flightDTO)
    {
        return _mapper.Map<Flight>(flightDTO);
    }

    internal object ConvertFlightDTOToFlight(IQueryable<Flight> flights)
    {
        throw new NotImplementedException();
    }
}