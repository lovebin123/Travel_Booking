using System;
using api.DTO.Flight;
using api.Helpers;
using api.Models;
using api.Models.Flights;

namespace api.Interfaces.Flights
{
    public interface IFlightRepository : IRepository<FlightEnitity>
    {
       IEnumerable<string> GetSources();
        IEnumerable<string> GetDestinations();
        Task<int> GetTotalCountAsync();
        Task<(IEnumerable<ResponseFlightDto> Flights, int TotalCount)> GetPagedAsync(int skip, int take);
    }
}
