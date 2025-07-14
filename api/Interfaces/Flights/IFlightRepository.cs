using System;
using api.DTO.Flight;
using api.Helpers;
using api.Models;
using api.Models.Flights;

namespace api.Interfaces.Flights
{
    public interface IFlightRepository
    {
        Task<Flight?> GetByIdAsync(int id);
        Task<List<Flight>> GetFlightsByQuery(QueryObject query);
        Task<(List<Flight>flights1,int totalCount)> GetAllFlights(int PageNumber,int PageSize);
        Task<List<Flight>> GetSearchFlights(string flightName);
        List<string> GetSources();
        List<string> GetDestinations();
        Task<Flight> CreateFlight(FlightDTO flightModal);
        Task<Flight> GetById(int id);
        Task<Flight> UpdateFlight(int id, FlightDTO flightDTO);
        Task DeleteById(int id);
    }
}
