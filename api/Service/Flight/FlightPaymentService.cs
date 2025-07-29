using api.Data;
using api.Interfaces;
using api.Models;
using api.Models.Flights;
using Microsoft.EntityFrameworkCore;

namespace api.Service.Flight
{
    public class FlightPaymentService : IFlightPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FlightPaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FlightPayement>> GetAllPaymentsAsync(AppUser user)
        {
            return await _unitOfWork.FlightPaymentRepository.GetAllPayments(user);
        }

        public async Task<FlightPayement?> GetByPaymentIntentIdAsync(string id)
        {
            return await _unitOfWork.FlightPaymentRepository.GetById(id);
        }

        public async Task<FlightPayement?> GetLatestPaymentAsync(string sessionId)
        {
            var payment = await _unitOfWork.FlightPaymentRepository.GetLatestPayment(sessionId);

            if (payment == null)
                return null;
            await _unitOfWork.FlightPaymentRepository.DeductFlightSeatsAsync(payment.FlightBookingId);

            return payment;
        }
    }
}
