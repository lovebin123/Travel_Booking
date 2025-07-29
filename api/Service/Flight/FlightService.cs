using api.DTO.Flight;
using api.Helpers;
using api.Interfaces;
using api.Models;
using api.Models.Flights;
using Microsoft.EntityFrameworkCore;

namespace api.Service.Flight
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly FlightMapper _flightMapper;

        public FlightService(IUnitOfWork unitOfWork, FlightMapper flightMapper)
        {
            _unitOfWork = unitOfWork;
            _flightMapper = flightMapper;
        }

        public async Task<List<api.Models.Flights.Flight>> GetFlightsByQuery(QueryObject query)
        {
            var flights = _unitOfWork.Repository<api.Models.Flights.Flight>().GetQueryable();

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
            var flights = _unitOfWork.Repository<api.Models.Flights.Flight>().GetQueryable();

            if (!string.IsNullOrWhiteSpace(flightName))
                flights = flights.Where(x => x.name.ToLower().Contains(flightName.ToLower()));

            return await flights.ToListAsync();
        }

        public async Task<List<string>> GetSources()
        {
            return await _unitOfWork.Repository<api.Models.Flights.Flight>()
                .GetQueryable()
                .Select(f => f.source)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<string>> GetDestinations()
        {
            return await _unitOfWork.Repository<api.Models.Flights.Flight>()
                .GetQueryable()
                .Select(f => f.destination)
                .Distinct()
                .ToListAsync();
        }

        public async Task<api.Models.Flights.Flight> GetById(int id)
        {
            var flight = await _unitOfWork.Repository<api.Models.Flights.Flight>().GetByIdAsync(id);
            if (flight == null)
                throw new Exception("Flight not found");

            return flight;
        }

        public async Task<(List<api.Models.Flights.Flight> Flights, int TotalCount)> GetPagedFlightsAsync(int pageSize, int pageNumber)
        {
            var query = _unitOfWork.Repository<api.Models.Flights.Flight>().GetQueryable();
            var totalCount = await query.CountAsync();

            var flights = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (flights, totalCount);
        }

        public async Task<api.Models.Flights.Flight> CreateFlightAsync(FlightDTO dto)
        {
            var flight = _flightMapper.ConvertFlightDTOToFlight(dto);
            await _unitOfWork.Repository<api.Models.Flights.Flight>().AddAsync(flight);
            await _unitOfWork.CompleteAsync();
            return flight;
        }

        public async Task<api.Models.Flights.Flight> UpdateFlightAsync(int id, FlightDTO dto)
        {
            var flight = await _unitOfWork.Repository<api.Models.Flights.Flight>().GetByIdAsync(id);
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

            _unitOfWork.Repository<api.Models.Flights.Flight>().Update(flight);
            await _unitOfWork.CompleteAsync();

            return flight;
        }

        public async Task DeleteFlightAsync(int id)
        {
            var flight = await _unitOfWork.Repository<api.Models.Flights.Flight>().GetByIdAsync(id);
            if (flight == null)
                throw new Exception("Flight not found");

            _unitOfWork.Repository<api.Models.Flights.Flight>();
            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<api.Models.Flights.Flight>> SearchByName(string name)
        {
            var flights = _unitOfWork.Repository<api.Models.Flights.Flight>().GetQueryable();
            if (!string.IsNullOrEmpty(name))
                flights = flights.Where(x => x.name.Contains(name));

            return await flights.ToListAsync();
        }
    }
}
