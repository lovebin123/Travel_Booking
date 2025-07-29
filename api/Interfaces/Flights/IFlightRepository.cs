using System;
using api.DTO.Flight;
using api.Helpers;
using api.Models;
using api.Models.Flights;

namespace api.Interfaces.Flights
{
    public interface IFlightRepository : IRepository<Flight>
    {
        List<string> GetSources();
        List<string> GetDestinations();
        Task<int> GetTotalCountAsync();
        Task<(List<Flight> Flights, int TotalCount)> GetPagedAsync(int skip, int take);
    }
}
