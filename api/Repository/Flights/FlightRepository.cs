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
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613,8604

namespace api.Repository.Flights
{
    public class FlightRepository :GenericRepository<FlightEnitity>, IFlightRepository
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
                .Distinct()
                .ToList();
        }

        public List<string> GetDestinations()
        {
            return _context.Flights
                .Select(x => x.destination)
                .Distinct()
                .ToList();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Flights.CountAsync();
        }

        public async Task<(List<ResponseFlightDto> Flights, int TotalCount)> GetPagedAsync(int pageSize, int pageNumber)
        {
            var totalCount = await _context.Flights.CountAsync();

            var flights = await _context.Flights
                .OrderBy(f => f.id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x=>new ResponseFlightDto
                {
                    date_of_departure=x.date_of_departure,
                    destination=x.destination,
                    FlightBookings = x.FlightBookings,
                    id=x.id,
                    name=x.name,
                    no_of_seats=x.no_of_seats,
                    price=x.price,
                    seatType = x.seatType,
                    source=x.source,
                    time_of_arrival=x.time_of_arrival,
                    time_of_departure = x.time_of_departure,
                    

                })
                .ToListAsync();

            return (flights, totalCount);
        }
    }
}
