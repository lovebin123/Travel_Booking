using api.DTO.Flight;
using api.Helpers;
using api.Interfaces;
using api.Models;
using api.Models.Flights;
using Microsoft.EntityFrameworkCore;
using Serilog;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613
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

        public async Task<List<ResponseFlightDto?>> GetFlightsByQuery(QueryObject query)
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

            return await flights.OrderBy(x => x.price).Select(x => new ResponseFlightDto
            {
                destination = x.destination,
                id = x.id,
                name = x.name,
                time_of_arrival = x.time_of_arrival,
                source = x.source,
                seatType = x.seatType,
                date_of_departure=x.date_of_departure,
                FlightBookings= x.FlightBookings.ToList(),
                no_of_seats=x.no_of_seats,
                price=x.price,
                time_of_departure = x.time_of_departure,
               
            }).ToListAsync();
        }

        public async Task<List<ResponseFlightDto>> SearchFlights(string flightName)
        {
            var flight = _unitOfWork.Repository<api.Models.Flights.Flight>().GetQueryable();

            if (!string.IsNullOrWhiteSpace(flightName))
                flight = flight.Where(x => x.name.ToLower().Contains(flightName.ToLower()));
            
            return await flight.Select(x=>new ResponseFlightDto
            {
                price = x.price,
                date_of_departure = x.date_of_departure,
                destination = x.destination,
                id = x.id,
                name = x.name,
                no_of_seats = x.no_of_seats,
                seatType = x.seatType,
                source = x.source,
                time_of_arrival = x.time_of_arrival,
                time_of_departure = x.time_of_departure,
                FlightBookings=x.FlightBookings.ToList()

            }).ToListAsync();
        }

        public async Task<List<string>> GetSources()
        {
            return await _unitOfWork.Repository<api.Models.Flights.Flight>().GetQueryable().Select(f => f.source).Distinct().ToListAsync();
        }

        public async Task<List<string>> GetDestinations()
        {
            return await _unitOfWork.Repository<api.Models.Flights.Flight>().GetQueryable().Select(f => f.destination).Distinct().ToListAsync();
        }

        public async Task<ResponseFlightDto> GetById(int id)
        {
            var flight = await _unitOfWork.Repository<api.Models.Flights.Flight>().GetByIdAsync(id);
            if (flight == null)
            {
                Log.Error("Flight not found");
                throw new Exception("Flight not found");
            }
            var response = new ResponseFlightDto
            {
                source = flight.source,
                destination = flight.destination,
                seatType = flight.seatType,
                price = flight.price,
                date_of_departure = flight.date_of_departure,
                no_of_seats = flight.no_of_seats,
                id = flight.id,
                name = flight.name,
                time_of_arrival = flight.time_of_arrival,
                FlightBookings = flight.FlightBookings.ToList(),
                time_of_departure = flight.time_of_departure
            };
            return response;
        }

        public async Task<(List<ResponseFlightDto> Flights, int TotalCount)> GetPagedFlightsAsync(int pageSize, int pageNumber)
        {
            var query = _unitOfWork.Repository<api.Models.Flights.Flight>().GetQueryable();
            var totalCount = await query.CountAsync();

            var flights = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize)
   .Select(x=>new ResponseFlightDto
                {
                    price = x.price,
                    date_of_departure=x.date_of_departure,
                    destination=x.destination,
                    id=x.id,
                    name=x.name,
                    no_of_seats = x.no_of_seats,
                    seatType = x.seatType,
                    source=x.source,
                    time_of_arrival=x.time_of_arrival,
                    time_of_departure = x.time_of_departure,
                })
                .ToListAsync();

            return (flights, totalCount);
        }

        public async Task<ResponseFlightDto> CreateFlightAsync(FlightDTO dto)
        {
            var flight = _flightMapper.ConvertFlightDTOToFlight(dto);
            await _unitOfWork.Repository<api.Models.Flights.Flight>().AddAsync(flight);
            await _unitOfWork.CompleteAsync();
            var responseDto = new ResponseFlightDto
            {
                date_of_departure = flight.date_of_departure,
                destination = flight.destination,
                id = flight.id,
                name = flight.name,
                no_of_seats = flight.no_of_seats,
                seatType = flight.seatType,
                source = flight.source,
                price = flight.price,
                time_of_arrival = flight.time_of_arrival,
                time_of_departure = flight.time_of_departure,
                FlightBookings=flight.FlightBookings.ToList()
            };
            return responseDto;
        }

        public async Task<ResponseFlightDto> UpdateFlightAsync(int id, FlightDTO dto)
        {
            var flight = await _unitOfWork.Repository<api.Models.Flights.Flight>().GetByIdAsync(id);
            if (flight == null)
            {
                Log.Error("Flight not found");
                throw new Exception("Flight not found");
            }

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
            Log.Information("Flight updated successfully");
            var responseDto = new ResponseFlightDto
            {
                date_of_departure = flight.date_of_departure,
                destination = flight.destination,
                id = flight.id,
                name = flight.name,
                no_of_seats = flight.no_of_seats,
                seatType = flight.seatType,
                source = flight.source,
                price = flight.price,
                time_of_arrival = flight.time_of_arrival,
                time_of_departure = flight.time_of_departure,
                FlightBookings = flight.FlightBookings.ToList()
            };
            return responseDto;
        }

        public async Task DeleteFlightAsync(int id)
        {
            var flight = await _unitOfWork.Repository<api.Models.Flights.Flight>().GetByIdAsync(id);
            if (flight == null)
            {
                Log.Error("Flight not found");
                throw new Exception("Flight not found");
            }
            Log.Information("Flight fetched");
            _unitOfWork.Repository<api.Models.Flights.Flight>().Remove(flight);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<ResponseFlightDto>> SearchByName(string name)
        {
            var flights = _unitOfWork.Repository<api.Models.Flights.Flight>().GetQueryable();
            if (!string.IsNullOrEmpty(name))
                flights = flights.Where(x => x.name.Contains(name));

            return await flights.Select(x=>new ResponseFlightDto
            {
                name = x.name,
                date_of_departure=x.date_of_departure,
                FlightBookings=x.FlightBookings.ToList(),
                time_of_departure= x.time_of_departure,
                time_of_arrival=x.time_of_arrival,
                destination= x.destination,
                id=x.id,
                no_of_seats=x.no_of_seats, 
                price=x.price,
                seatType=x.seatType,
                source = x.source
            }).ToListAsync();
        }
    }
}
