using System;
using api.Data;
using api.DTO.Flight;
using api.Helpers;
using api.Interfaces;
using api.Interfaces.Flights;
using api.Mappers;
using api.Models.Flights;
using api.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Flights
{
    public class FlightRepository :GenericRepository<Flight>, IFlightRepository
    {
        private readonly ApplicationDBContext _context;

        public FlightRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public List<string> GetSources()
        {
            return _context.Flights
                .Select(x => x.source)
                .Where(x => !string.IsNullOrEmpty(x))
                .Distinct()
                .ToList();
        }

        public List<string> GetDestinations()
        {
            return _context.Flights
                .Select(x => x.destination)
                .Where(x => !string.IsNullOrEmpty(x))
                .Distinct()
                .ToList();
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
