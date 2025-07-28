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
        public FlightRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public IQueryable<Flight> GetFlightsAsQueryable()
        {
            return _context.Flights.AsQueryable();
        }

        public async Task<Flight?> GetByIdAsync(int id)
        {
            return await _context.Flights.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task AddAsync(Flight flight)
        {
            await _context.Flights.AddAsync(flight);
        }

        public void Update(Flight flight)
        {
            _context.Flights.Update(flight);
        }

        public void Delete(Flight flight)
        {
            _context.Flights.Remove(flight);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public List<string> GetSources()
        {

            var flights= _context.Flights.Select(x => x.source).ToList();
            return flights;
        }

        public List<string> GetDestinations()
        {
            return _context.Flights.Select(x => x.destination).Distinct().ToList();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Flights.CountAsync();
        }

        public async Task<(List<Flight> Flights, int TotalCount)> GetPagedAsync(int pageSize, int pageNumber)
        {
            var totalCount = await _context.Flights.CountAsync();

            var flights = await _context.Flights
                .OrderBy(f => f.id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (flights, totalCount);
        }
    }
}
