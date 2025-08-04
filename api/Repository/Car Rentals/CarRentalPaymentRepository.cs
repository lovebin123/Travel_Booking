using System;
using api.Data;
using api.Interfaces.Car_Rentals;
using api.Models;
using api.Models.Car_Rental;
using Microsoft.EntityFrameworkCore;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613,8604
namespace api.Repository.Car_Rentals
{
    public class CarRentalPaymentRepository : ICarRentalPaymentRepository
    {
        private readonly ApplicationDBContext _context;
        public CarRentalPaymentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<CarRentalPaymentEntity> GetById(string paymentId)
        {
            var payment = await _context.CarRentalPayments.Include(x => x.carRentalBooking).Include(x => x.carRentalBooking.carRental).Include(x => x.carRentalBooking.user).Where(x => string.Compare(x.stripe_payement_intent_id, paymentId) == 0).FirstOrDefaultAsync();
            return payment;
        }

        public async Task<List<CarRentalPaymentEntity>> GetCarRentalPayments(AppUser user)
        {
            var payments = await _context.CarRentalPayments.Where(x => x.carRentalBooking.user_id == user.Id).Select(x => new CarRentalPaymentEntity
            {
                amount = x.amount,
                stripe_payement_intent_id = x.stripe_payement_intent_id,
                card = x.card,
                id = x.id,
                carRentalBooking = new CarRentalBookingEntity
                {
                    bookedFromDate = x.carRentalBooking.bookedFromDate,
                    bookedTillDate = x.carRentalBooking.bookedTillDate,
                    bookedFromTime = x.carRentalBooking.bookedFromTime,
                    bookedTillTime = x.carRentalBooking.bookedTillTime,
                    carRental = new CarRentalEntity
                    {
                        car_name = x.carRentalBooking.carRental.car_name
                    }
                }

            }).ToListAsync();
            return payments;

        }

        public async Task<CarRentalPaymentEntity> GetLatestCarRentalPayment(string sessionId)
        {
            var payement = await _context.CarRentalPayments.Where(x => string.Compare(x.sessionId, sessionId) == 0).Include(x => x.carRentalBooking).Include(x => x.carRentalBooking.carRental).Include(x => x.carRentalBooking.user).FirstOrDefaultAsync();
            return payement;
        }
    }
}