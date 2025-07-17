using System;
using api.Data;
using api.DTO.Flight;
using api.Helpers;
using api.Interfaces;
using api.Interfaces.Flights;
using api.Mappers;
using api.Models.Flights;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Flights
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly FlightMapper _flightMapper;
        public FlightRepository(ApplicationDBContext context, FlightMapper flightMapper)
        {
            _context = context;
            _flightMapper = flightMapper;
        }
        public async Task<List<Flight>> GetFlightsByQuery(QueryObject query)
        {
            var flights = _context.Flights.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.source))
            {
                flights = flights.Where(s => s.source.Contains(query.source.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(query.destination))
            {
                flights = flights.Where(s => s.destination.Contains(query.destination.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(query.date_of_departure))
            {
                flights = flights.Where(s => s.date_of_departure == query.date_of_departure);
            }
            if (!string.IsNullOrWhiteSpace(query.seatType))
            {
                flights = flights.Where(s => s.seatType.Contains(query.seatType.ToLower()));
            }
            return await flights.OrderBy(x => x.price).ToListAsync();
        }
        public async Task<List<Flight>> GetSearchFlights(string flightName)
        {
            var flights = _context.Flights.AsQueryable();
            if (!string.IsNullOrWhiteSpace(flightName))
            {
                flights = flights.Where(x => x.name.Contains(flightName.ToLower()));
            }
            return await flights.ToListAsync();
        }
        public List<string> GetSources()
        {
            var sources = _context.Flights.Select(x => x.source).ToList();
            return sources;
        }

        public async Task<Flight?> GetByIdAsync(int id)
        {
            return await _context.Flights.FirstOrDefaultAsync(x => x.id == id);
        }

        public List<string> GetDestinations()
        {
            var destinations = _context.Flights.Select(x => x.destination).ToList();
            return destinations;
        }

        public async Task<(List<Flight>flights1,int totalCount)> GetAllFlights(int PageSize,int PageNumber)
        {
            var totalCount = await _context.Flights.CountAsync();
            var flights = await _context.Flights.Select(x => new Flight
            {
                date_of_departure = x.date_of_departure,
                destination = x.destination,
                name = x.name,
                no_of_seats = x.no_of_seats,
                price = x.price,
                seatType = x.seatType,
                source = x.source,
                id = x.id,
                time_of_arrival = x.time_of_arrival,
                time_of_departure = x.time_of_departure
            }).Skip((PageSize-1)*PageNumber).Take(PageNumber).ToListAsync();
            return (flights,totalCount);
        }

        public async Task<Flight> CreateFlight(FlightDTO flightModal)
        {

            var flights = _flightMapper.ConvertFlightDTOToFlight(flightModal);
            await _context.AddAsync(flights);
            await _context.SaveChangesAsync();
            return flights;
        }
        public async Task<Flight> GetById(int id)
        {
            var flight = await _context.Flights.Where(x => x.id == id).FirstOrDefaultAsync();
            return flight;
        }

        public async Task<Flight> UpdateFlight(int id, FlightDTO flightDTO)
        {
            var flights = await _context.Flights.Where(x => x.id == id).FirstOrDefaultAsync();
            flights.date_of_departure = flightDTO.date_of_departure;
            flights.destination = flightDTO.destination;
            flights.name = flightDTO.name;
            flights.no_of_seats = flightDTO.no_of_seats;
            flights.price = flightDTO.price;
            flights.seatType = flightDTO.seatType;
            flights.time_of_arrival = flightDTO.time_of_arrival;
            flights.source = flightDTO.source;
            flights.time_of_departure = flightDTO.time_of_departure;
            _context.SaveChanges();
            return flights;
        }

        public async Task DeleteById(int id)
        {
            var flights = await _context.Flights.FirstOrDefaultAsync(x=>x.id==id);
            _context.Flights.Remove(flights);
            _context.SaveChanges();
            
        }

        public Task<FlightDTO> SampleFlightToFlightDTO(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
