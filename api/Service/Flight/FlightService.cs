using api.DTO.Flight;
using api.Helpers;
using api.Interfaces.Flights;
using api.Models;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
namespace api.Service.Flight
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly FlightMapper _flightMapper;

        public FlightService(IFlightRepository flightRepository, FlightMapper flightMapper)
        {
            _flightRepository = flightRepository;
            _flightMapper = flightMapper;
        }

        public async Task<List<api.Models.Flights.Flight>> GetFlightsByQuery(QueryObject query)
        {
            var flights = _flightRepository.GetFlightsAsQueryable();

            if (!string.IsNullOrWhiteSpace(query.source))
                flights = flights.Where(s => s.source.ToLower().Contains(query.source.ToLower()));

            if (!string.IsNullOrWhiteSpace(query.destination))
                flights = flights.Where(s => s.destination.ToLower().Contains(query.destination.ToLower()));

            if (!string.IsNullOrWhiteSpace(query.date_of_departure))
                flights = flights.Where(s => s.date_of_departure == query.date_of_departure);

            if (!string.IsNullOrWhiteSpace(query.seatType))
                flights = flights.Where(s => s.seatType.ToLower().Contains(query.seatType.ToLower()));

            return await flights.OrderBy(x => x.price).ToListAsync();
        }

        public async Task<List<api.Models.Flights.Flight>> SearchFlights(string flightName)
        {
            var flights = _flightRepository.GetFlightsAsQueryable();

            if (!string.IsNullOrWhiteSpace(flightName))
                flights = flights.Where(x => x.name.ToLower().Contains(flightName.ToLower()));

            return await flights.ToListAsync();
        }

        public async Task<List<string>> GetSources()
        {
            return _flightRepository.GetSources();
        }

        public async Task<List<string>> GetDestinations()
        {
            return _flightRepository.GetDestinations();
        }

        public async Task<api.Models.Flights.Flight> GetById(int id)
        {
            var flight = await _flightRepository.GetByIdAsync(id);
            if (flight == null)
                throw new Exception("Flight not found");

            return flight;
        }

        public async Task<(List<api.Models.Flights.Flight> Flights, int TotalCount)> GetPagedFlightsAsync(int pageSize, int pageNumber)
        {
            var (flights, totalCount) = await _flightRepository.GetPagedAsync(pageSize, pageNumber);
            return (flights, totalCount);
        }

        public async Task<api.Models.Flights.Flight> CreateFlightAsync(FlightDTO dto)
        {
            var flight = _flightMapper.ConvertFlightDTOToFlight(dto);
            await _flightRepository.AddAsync(flight);
            await _flightRepository.SaveChangesAsync();
            return flight;
        }

        public async Task<api.Models.Flights.Flight> UpdateFlightAsync(int id, FlightDTO dto)
        {
            var flight = await _flightRepository.GetByIdAsync(id);
            if (flight == null)
                throw new Exception("Flight not found");

            flight.name = dto.name;
            flight.source = dto.source;
            flight.destination = dto.destination;
            flight.date_of_departure = dto.date_of_departure;
            flight.time_of_arrival = dto.time_of_arrival;
            flight.time_of_departure = dto.time_of_departure;
            flight.no_of_seats = dto.no_of_seats;
            flight.price = dto.price;
            flight.seatType = dto.seatType;

            _flightRepository.Update(flight);
            await _flightRepository.SaveChangesAsync();

            return flight;
        }

        public async Task DeleteFlightAsync(int id)
        {
            var flight = await _flightRepository.GetByIdAsync(id);
            if (flight == null)
                throw new Exception("Flight not found");

            _flightRepository.Delete(flight);
            await _flightRepository.SaveChangesAsync();
        }

        public async Task<List<Models.Flights.Flight>> SearchByName(string name)
        {
            var flights = _flightRepository.GetFlightsAsQueryable();
            if(!string.IsNullOrEmpty(name))
                flights = flights.Where(x => x.name.Contains(name)) ;
            
            return await flights.ToListAsync();
        }
    }

}
