using System;
using api.Data;
using api.Interfaces.Hotels;
using api.Models.Hotels;
using DotNetEnv;
using Microsoft.AspNetCore.Http.HttpResults;
using Stripe;
using Stripe.Checkout;

namespace api.Repository.Hotels
{
    public class HotelStripeRepository : IHotelStripeRepository
    {
        private readonly ApplicationDBContext _context;

        public HotelStripeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<HotelPaymentEntity> CreateHotelPayment(HotelPaymentEntity payment)
        {
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
    }
}
