using api.Data;
using api.DTO.Flight;
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

        public async Task<List<ResponseFlightPaymentDto>> GetAllPaymentsAsync(AppUser user)
        {
            var response= await _unitOfWork.FlightPaymentRepository.GetAllPayments(user);
            var responseDto = response.Select(payment => new ResponseFlightPaymentDto
            {
                id = payment.id,
                stripe_payement_intent_id = payment.stripe_payement_intent_id,
                payement_status = payment.payement_status,
                amount = payment.amount,
                sessionId = payment.sessionId,
                card = payment.card,
                FlightBookingId = payment.FlightBookingId,

                flightBooking = new ResponseFlightBookingDto
                {
                    id = payment.flightBooking.id,
                    flight_id = payment.flightBooking.flight_id,
                    user_id = payment.flightBooking.user_id,
                    isBooked = payment.flightBooking.isBooked,
                    amount = payment.flightBooking.amount,
                    no_of_adults = payment.flightBooking.no_of_adults,
                    no_of_children = payment.flightBooking.no_of_children,
                    paymentId = payment.flightBooking.paymentId,
                    Flight = new ResponseFlightDto
                    {
                        date_of_departure = payment.flightBooking.Flight.date_of_departure,
                        destination = payment.flightBooking.Flight.destination,
                        id = payment.flightBooking.flight_id,
                        name = payment.flightBooking.Flight.name,
                        no_of_seats = payment.flightBooking.Flight.no_of_seats,
                        price = payment.flightBooking.Flight.price,
                        seatType = payment.flightBooking.Flight.seatType,
                        source = payment.flightBooking.Flight.source,
                        time_of_arrival = payment.flightBooking.Flight.time_of_arrival,
                        time_of_departure = payment.flightBooking.Flight.time_of_departure,
                        FlightBookings = new List<ResponseFlightBookingDto>()
                    }
                }
            }).ToList();
            return responseDto;
             
        }

        public async Task<ResponseFlightPaymentDto?> GetByPaymentIntentIdAsync(string id)
        {
            var payment =   await _unitOfWork.FlightPaymentRepository.GetById(id);
            var responseDto = new ResponseFlightPaymentDto
            {
                id = payment.id,
                stripe_payement_intent_id = payment.stripe_payement_intent_id,
                payement_status = payment.payement_status,
                amount = payment.amount,
                sessionId = payment.sessionId,
                card = payment.card,
                FlightBookingId = payment.FlightBookingId,
                flightBooking = new ResponseFlightBookingDto
                {
                    id = payment.flightBooking.id,
                    flight_id = payment.flightBooking.flight_id,
                    user_id = payment.flightBooking.user_id,
                    isBooked = payment.flightBooking.isBooked,
                    amount = payment.flightBooking.amount,
                    no_of_adults = payment.flightBooking.no_of_adults,
                    no_of_children = payment.flightBooking.no_of_children,
                    paymentId = payment.flightBooking.paymentId,
                    AppUser = new DTO.Account.AppUserDto
                    {
                        Email = payment.flightBooking.AppUser.Email,
                        FirstName = payment.flightBooking.AppUser.FirstName,
                        LastName = payment.flightBooking.AppUser.LastName,
                        Id = payment.flightBooking.AppUser.Id
                    },
                    Flight = new ResponseFlightDto
                    {
                        date_of_departure = payment.flightBooking.Flight.date_of_departure,
                        destination = payment.flightBooking.Flight.destination,
                        id = payment.flightBooking.flight_id,
                        name = payment.flightBooking.Flight.name,
                        no_of_seats = payment.flightBooking.Flight.no_of_seats,
                        price = payment.flightBooking.Flight.price,
                        seatType = payment.flightBooking.Flight.seatType,
                        source = payment.flightBooking.Flight.source,
                        time_of_arrival = payment.flightBooking.Flight.time_of_arrival,
                        time_of_departure = payment.flightBooking.Flight.time_of_departure,
                        FlightBookings = new List<ResponseFlightBookingDto>()
                    }
                }
            };
            return responseDto;
        }

        public async Task<ResponseFlightPaymentDto?> GetLatestPaymentAsync(string sessionId)
        {
            var payment = await _unitOfWork.FlightPaymentRepository.GetLatestPayment(sessionId);

            if (payment == null)
                return null;
            await _unitOfWork.FlightPaymentRepository.DeductFlightSeatsAsync(payment.FlightBookingId);
            var responseDto = new ResponseFlightPaymentDto
            {
                id = payment.id,
                stripe_payement_intent_id = payment.stripe_payement_intent_id,
                payement_status = payment.payement_status,
                amount = payment.amount,
                sessionId = payment.sessionId,
                card = payment.card,
                FlightBookingId = payment.FlightBookingId,
                flightBooking = new ResponseFlightBookingDto
                {
                    id = payment.flightBooking.id,
                    flight_id = payment.flightBooking.flight_id,
                    user_id = payment.flightBooking.user_id,
                    isBooked = payment.flightBooking.isBooked,
                    amount = payment.flightBooking.amount,
                    no_of_adults = payment.flightBooking.no_of_adults,
                    no_of_children = payment.flightBooking.no_of_children,
                    paymentId = payment.flightBooking.paymentId,
                    AppUser=new DTO.Account.AppUserDto
                    {
                        Email=payment.flightBooking.AppUser.Email,
                        FirstName=payment.flightBooking.AppUser.FirstName,
                        LastName=payment.flightBooking.AppUser.LastName,
                        Id = payment.flightBooking.AppUser.Id
                    },
                    Flight = new ResponseFlightDto
                    {
                        date_of_departure = payment.flightBooking.Flight.date_of_departure,
                        destination = payment.flightBooking.Flight.destination,
                        id = payment.flightBooking.flight_id,
                        name = payment.flightBooking.Flight.name,
                        no_of_seats = payment.flightBooking.Flight.no_of_seats,
                        price = payment.flightBooking.Flight.price,
                        seatType = payment.flightBooking.Flight.seatType,
                        source = payment.flightBooking.Flight.source,
                        time_of_arrival = payment.flightBooking.Flight.time_of_arrival,
                        time_of_departure = payment.flightBooking.Flight.time_of_departure,
                        FlightBookings = new List<ResponseFlightBookingDto>()
                    }
                }
            };
            return responseDto;
        }
    }
}
