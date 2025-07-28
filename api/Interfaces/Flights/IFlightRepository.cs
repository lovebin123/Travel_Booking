using System;
using api.DTO.Flight;
using api.Helpers;
using api.Models;
using api.Models.Flights;

namespace api.Interfaces.Flights
{
    public interface IFlightRepository
    {
        IQueryable<Flight> GetFlightsAsQueryable();
        Task<Flight?> GetByIdAsync(int id);
        Task AddAsync(Flight flight);
        void Update(Flight flight);
        void Delete(Flight flight);
        Task<int> SaveChangesAsync();
        List<string> GetSources();
        List<string> GetDestinations();
        Task<int> GetTotalCountAsync();
        Task<(List<Flight> Flights, int TotalCount)> GetPagedAsync(int skip, int take);
    }
}
