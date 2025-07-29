using api.DTO.Flight;
using api.Helpers;
using api.Models.Flights;
namespace api.Service.Flight
{
    public interface IFlightService
    {
        Task<List<ResponseFlightDto>> GetFlightsByQuery(QueryObject query);
        Task<List<ResponseFlightDto>> SearchFlights(string flightName);
        Task<List<string>> GetSources();
        Task<List<string>> GetDestinations();
        Task<ResponseFlightDto> GetById(int id); 
        Task<List<ResponseFlightDto>>SearchByName(string name);
        Task<(List<ResponseFlightDto> Flights, int TotalCount)> GetPagedFlightsAsync(int pageSize, int pageNumber); 
        Task<ResponseFlightDto> CreateFlightAsync(FlightDTO dto); 
        Task<ResponseFlightDto> UpdateFlightAsync(int id, FlightDTO dto); 
        Task DeleteFlightAsync(int id); 
    }
}
