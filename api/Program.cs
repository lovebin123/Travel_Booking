using api.Data;
using api.Filters;
using api.Interfaces;
using api.Interfaces.Car_Rentals;
using api.Interfaces.Flights;
using api.Interfaces.Hotels;
using api.Mappers;
using api.Mappers.Hotels;
using api.Models;
using api.Repository.Car_Rentals;
using api.Repository.Flights;
using api.Repository.Generic;
using api.Repository.Hotels;
using api.Service;
using api.Service.CarRental;
using api.Service.Flight;
using api.Service.Hotels;
using AutoWrapper;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(Environment.GetEnvironmentVariable("DB_STRING"), options =>
{
    options.CommandTimeout(60);
}));
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;

}).AddEntityFrameworkStores<ApplicationDBContext>();
var jwtSettings = builder.Configuration.GetSection("JWT");
var signingKey = jwtSettings["SigningKey"];

if (string.IsNullOrEmpty(signingKey))
{
    throw new InvalidOperationException("JWT SigningKey is missing in configuration.");
}
var validationParams = new TokenValidationParameters
{
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),
    ValidateIssuer = true,
    ValidIssuer = jwtSettings["Issuer"],
    ValidateAudience = true,
    ValidAudience = jwtSettings["Audience"],
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    RoleClaimType = ClaimTypes.Role,
};
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        RoleClaimType = ClaimTypes.Role,
        ClockSkew = TimeSpan.Zero,
        RequireExpirationTime = true
    };
});

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<FlightMapper>();
builder.Services.AddScoped<HotelMapper>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IFlightBookingService, FlightBookingService>();
builder.Services.AddScoped<IStripeService, StripeService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IHotelBookingService, HotelBookingService>();
builder.Services.AddScoped<IHotelStripeService, HotelStripeService>();
builder.Services.AddScoped<IHotelPaymentService, HotelPaymentService>();
builder.Services.AddScoped<IFlightPaymentService, FlightPaymentService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IStripePayementRepository, StripeRepository>();
builder.Services.AddScoped<IFlightPaymentRepository, FlightPaymentRepository>();
builder.Services.AddScoped<IFlightBookingRepository, FlightBookingRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IHotelBookingRepository, HotelBookingRepository>();
builder.Services.AddScoped<IHotelStripeRepository, HotelStripeRepository>();
builder.Services.AddScoped<IHotelPaymentRepository, HotelPaymentRepository>();
builder.Services.AddScoped<ICarRentalRepository, CarRentalRepository>();
builder.Services.AddScoped<ICarRentalBookingRepository, CarRentalBookingRepository>();
builder.Services.AddScoped<ICarRentalStripeRepository, CarRentalStripeRepository>();
builder.Services.AddScoped<ICarRentalPaymentRepository, CarRentalPaymentRepository>();
builder.Services.AddCors();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomFilter>(); 
});
var log = new LoggerConfiguration().WriteTo.File("C:\\OneDrive - H&R BLOCK LTD\\Documents\\TravelBooking\\Travel_Booking\\api\\Logs\\log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
Log.Logger = log;
Env.Load();
var app = builder.Build();
app.UseApiResponseAndExceptionWrapper();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}
app.UseCors(x => x.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();