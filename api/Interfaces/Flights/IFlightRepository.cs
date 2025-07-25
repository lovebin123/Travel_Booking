using System;
using api.DTO.Flight;
using api.Helpers;
using api.Models;
using api.Models.Flights;

namespace api.Interfaces.Flights
{
    public interface IFlightRepository:IGenericRepository<Flight>
    {
        Task<List<Flight>> GetFlightsByQuery(QueryObject query);
        Task<(List<Flight>flights1,int totalCount)> GetAllFlights(int PageNumber,int PageSize);
        Task<List<Flight>> GetSearchFlights(string flightName);
        List<string> GetSources();
        List<string> GetDestinations();
      
    }
}
