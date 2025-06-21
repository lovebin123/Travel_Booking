using System;
using api.Data;
using api.Interfaces.Hotels;
using api.Models;
using api.Models.Hotels;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Hotels
{
    public class HotelPaymentRepository:IHotelPaymentRepository
    {
        private readonly ApplicationDBContext _context;
        public HotelPaymentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<HotelPayment> GetById(string id)
        {
            var payement = await _context.HotelPayments.Where(x =>string.Compare(x.stripe_payement_intent_id,id)==0).Include(x=>x.hotelBooking).Include(x=>x.hotelBooking.hotel).Include(x=>x.hotelBooking.user).FirstOrDefaultAsync();
            return payement;
        }

        public async Task<List<HotelPayment>> GetHotelPayments(AppUser user)
        {
            var payments = await _context.HotelPayments.Where(x => x.hotelBooking.user_id == user.Id).Select(x => new HotelPayment
            {
                amount = x.amount,
                Id = x.Id,
                stripe_payement_intent_id=x.stripe_payement_intent_id,
                card = x.card,
                hotelBooking = new HotelBooking
                {
                    check_in_date = x.hotelBooking.check_in_date,
                    check_out_date = x.hotelBooking.check_out_date,
                    hotel=new Hotel
                    {
                        name=x.hotelBooking.hotel.name
                    }
                }

            }).ToListAsync();
            return payments;
        }

        public async Task<HotelPayment?> GetLastPayment(string sessionId)
        {
            var payment = await _context.HotelPayments.Include(x=>x.hotelBooking).Include(x=>x.hotelBooking.user).Include(x=>x.hotelBooking.hotel).Where(x=>string.Compare(x.sessionId,sessionId)==0).FirstOrDefaultAsync();
            var rooms = payment.hotelBooking.no_of_rooms;
            if(payment.hotelBooking.hotel.no_of_rooms_available - rooms>=0)
           payment.hotelBooking.hotel.no_of_rooms_available = payment.hotelBooking.hotel.no_of_rooms_available - rooms;
           await  _context.SaveChangesAsync();
            return payment;
        }
    }
}
