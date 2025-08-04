using System;
using api.Models;
using api.Models.Flights;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces.Flights
{
    public interface IFlightPaymentRepository : IRepository<FlightPayementEntity>
    {
        Task<FlightPayementEntity?> GetLatestPayment(string sessionId);
        Task<List<FlightPayementEntity>> GetAllPayments(AppUser user);
        Task<FlightPayementEntity?> GetById(string intentId);
        Task DeductFlightSeatsAsync(int bookingId);
    }
}
