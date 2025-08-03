using api.Interfaces;
using api.Interfaces.Car_Rentals;
using api.Interfaces.Flights;
using api.Interfaces.Hotels;
using api.Repository.Car_Rentals;
using api.Repository.Flights;
using api.Repository.Hotels;
using api.Service;
using api.Service.Account;
using api.Service.Flight;
using api.Service.Hotels;

namespace api.Configurations
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection RegisterServicesRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFlightRepository, FlightRepository>();
           services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IFlightBookingService, FlightBookingService>();
            services.AddScoped<IStripeService, StripeService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IHotelBookingService, HotelBookingService>();
            services.AddScoped<IHotelStripeService, HotelStripeService>();
            services.AddScoped<IHotelPaymentService, HotelPaymentService>();
            services.AddScoped<IFlightPaymentService, FlightPaymentService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IStripePayementRepository, StripeRepository>();
            services.AddScoped<IFlightPaymentRepository, FlightPaymentRepository>();
            services.AddScoped<IFlightBookingRepository, FlightBookingRepository>();
          services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelBookingRepository, HotelBookingRepository>();
            services.AddScoped<IHotelStripeRepository, HotelStripeRepository>();
            services.AddScoped<IHotelPaymentRepository, HotelPaymentRepository>();
            services.AddScoped<ICarRentalRepository, CarRentalRepository>();
            services.AddScoped<ICarRentalBookingRepository, CarRentalBookingRepository>();
            services.AddScoped<ICarRentalStripeRepository, CarRentalStripeRepository>();
            services.AddScoped<ICarRentalPaymentRepository, CarRentalPaymentRepository>();
            return services;
        }
    }
}
