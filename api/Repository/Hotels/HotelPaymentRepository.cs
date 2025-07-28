using System;
using api.Data;
using api.Interfaces.Hotels;
using api.Models;
using api.Models.Hotels;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Hotels
{
    public class HotelPaymentRepository : IHotelPaymentRepository
    {
        private readonly ApplicationDBContext _context;
        public HotelPaymentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<HotelPayment> GetById(string id)
        {
            return await _context.HotelPayments
                .Where(x => string.Compare(x.stripe_payement_intent_id, id) == 0)
                .Include(x => x.hotelBooking)
                .ThenInclude(b => b.hotel)
                .Include(x => x.hotelBooking.user)
                .FirstOrDefaultAsync();
        }

        public async Task<List<HotelPayment>> GetHotelPayments(AppUser user)
        {
            return await _context.HotelPayments
                .Where(x => x.hotelBooking.user_id == user.Id)
                .Select(x => new HotelPayment
                {
                    amount = x.amount,
                    Id = x.Id,
                    stripe_payement_intent_id = x.stripe_payement_intent_id,
                    card = x.card,
                    hotelBooking = new HotelBooking
                    {
                        check_in_date = x.hotelBooking.check_in_date,
                        check_out_date = x.hotelBooking.check_out_date,
                        hotel = new Hotel
                        {
                            name = x.hotelBooking.hotel.name
                        }
                    }
                }).ToListAsync();
        }

        public async Task<HotelPayment?> GetLastPayment(string sessionId)
        {
            return await _context.HotelPayments
                .Include(x => x.hotelBooking)
                .ThenInclude(b => b.hotel)
                .Include(x => x.hotelBooking.user)
                .Where(x => string.Compare(x.sessionId, sessionId) == 0)
                .FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
    }
