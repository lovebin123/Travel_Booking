using System;
using api.DTO.Account;
using api.DTO.Car_Rental;
using api.DTO.Flight;
using api.DTO.Hotel;
using api.Models.Car_Rental;
using api.Models.Flights;
using api.Models.Hotels;
using AutoMapper;
namespace api.Mappers
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<FlightEnitity, FlightDto>().ReverseMap();
            CreateMap<HotelEntity, HotelDTO>().ReverseMap();
            CreateMap<CarRentalEntity, CarRentalDto>().ReverseMap();
            CreateMap<ResponseFlightDto, FlightEnitity>().ReverseMap();
            CreateMap<ResponseFlightBookingDto,api.Models.Flights.FlightBookingEntity>().ReverseMap();

        }
    }
}
