using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Interfaces.Flights;
using Stripe.Checkout;
using Stripe;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models.Flights;
using DotNetEnv;

namespace api.Service
{
    public class StripeRepository : IStripePayementRepository
    {
        private readonly ApplicationDBContext _context;

        public StripeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task SavePaymentAsync(FlightPayementEntity payment)
        {
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();
        }
    }
}
