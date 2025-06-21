using System;
using api.Models;
using api.Models.Flights;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces.Flights
{
    public interface IFlightPaymentRepository
    {
        Task<FlightPayement> GetLatestPayment(string sessionId);
        Task<List<FlightPayement>> GetAllPayments(AppUser user);
        Task<FlightPayement> GetById(string id);
    }
}
