using api.DTO.Flight;
using api.Helpers;
using api.Models.Flights;
namespace api.Service.Flight
{
    public interface IFlightService
    {
        Task<IEnumerable<ResponseFlightDto?>> GetFlightsByQuery(QueryObjectDto query);
        Task<IEnumerable<ResponseFlightDto?>> SearchFlights(string flightName);
        Task<IEnumerable<string?>> GetSources();
        Task<IEnumerable<string?>> GetDestinations();
        Task<ResponseFlightDto?> GetById(int id); 
        Task<IEnumerable<ResponseFlightDto?>>SearchByName(string name);
        Task<(IEnumerable<ResponseFlightDto?> Flights, int TotalCount)> GetPagedFlightsAsync(int pageSize, int pageNumber); 
        Task<ResponseFlightDto> CreateFlightAsync(FlightDto dto); 
        Task<ResponseFlightDto> UpdateFlightAsync(int id, FlightDto dto); 
        Task DeleteFlightAsync(int id); 
    }
}
