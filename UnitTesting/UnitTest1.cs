using api.DTO.Flight;
using api.Helpers;
using api.Interfaces;
using api.Models.Flights;
using api.Repository.Generic;
using api.Service.Flight;
using AutoMapper;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTesting;
using Xunit;

public class FlightServiceTests
{
    [Fact]
    public async Task GetFlightsByQuery_ShouldReturnFilteredFlightsOrderedByPrice()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockFlightRepo = new Mock<IRepository<FlightEnitity>>();
        var mockMapper = new Mock<IMapper>();
        var flightData = new List<FlightEnitity>
        {
            new FlightEnitity {
                id = 1,
                name = "Air India",
                source = "Kochi",
                destination = "Bangalore",
                date_of_departure = "2025-08-10",
                seatType = "Economy",
                time_of_arrival = "10:00",
                time_of_departure = "08:00",
                price = 5000,
                no_of_seats = 100,
                FlightBookings = new List<FlightBookingEntity>()
            },
            new FlightEnitity {
                id = 2,
                name = "Indigo",
                source = "Kochi",
                destination = "Bangalore",
                date_of_departure = "2025-08-10",
                seatType = "Economy",
                time_of_arrival = "11:00",
                time_of_departure = "09:00",
                price = 4500,
                no_of_seats = 90,
                FlightBookings = new List<FlightBookingEntity>()
            }
        }.AsQueryable();
        mockFlightRepo.Setup(r => r.GetQueryable()).Returns(new TestAsyncEnumerable<FlightEnitity>(flightData));
        mockUnitOfWork.Setup(u => u.Repository<FlightEnitity>()).Returns(mockFlightRepo.Object);

        // Set up AutoMapper
        mockMapper.Setup(m => m.Map<ResponseFlightDto>(It.IsAny<FlightEnitity>()))
            .Returns<FlightEnitity>(f => new ResponseFlightDto
            {
                id = f.id,
                name = f.name,
                source = f.source,
                destination = f.destination,
                date_of_departure = f.date_of_departure,
                seatType = f.seatType,
                time_of_departure = f.time_of_departure,
                time_of_arrival = f.time_of_arrival,
                price = f.price,
                no_of_seats = f.no_of_seats,
                FlightBookings = new List<ResponseFlightBookingDto>()
            });

        var flightMapper = new FlightMapper(mockMapper.Object);
        var service = new FlightService(mockUnitOfWork.Object, flightMapper);

        var query = new QueryObjectDto
        {
            source = "kochi",
            destination = "bangalore",
            date_of_departure = "2025-08-10",
            seatType = "economy"
        };

        // Act
        var result = await service.GetFlightsByQuery(query);

        // Assert
        result.Should().HaveCount(2);
        result.First().name.Should().Be("Indigo"); 
        result.All(f => f.source.ToLower().Contains("kochi")).Should().BeTrue();
        result.All(f => f.destination.ToLower().Contains("bangalore")).Should().BeTrue();
    }
}
