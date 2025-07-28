using api.DTO.Flight;
using api.Helpers;
using api.Models.Flights;
namespace api.Service.Flight
{
    public interface IFlightService
    {
        Task<List<api.Models.Flights.Flight>> GetFlightsByQuery(QueryObject query);
        Task<List<api.Models.Flights.Flight>> SearchFlights(string flightName);
        Task<List<string>> GetSources();
        Task<List<string>> GetDestinations();
        Task<api.Models.Flights.Flight> GetById(int id); 
        Task<List<api.Models.Flights.Flight>>SearchByName(string name);
        Task<(List<api.Models.Flights.Flight> Flights, int TotalCount)> GetPagedFlightsAsync(int pageSize, int pageNumber); 
        Task<api.Models.Flights.Flight> CreateFlightAsync(FlightDTO dto); 
        Task<api.Models.Flights.Flight> UpdateFlightAsync(int id, FlightDTO dto); 
        Task DeleteFlightAsync(int id); 
    }
}
