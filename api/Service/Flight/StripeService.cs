using api.DTO.Flight;
using api.Interfaces;
using api.Interfaces.Flights;
using api.Models.Flights;
using Stripe;
using Stripe.Checkout;
namespace api.Service.Flight
{
    public class StripeService : IStripeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StripeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("STRIPE_ID");
        }

        public async Task<Session> CreateFlightBookingPaymentSession(int bookingId)
        {
            var booking = await _unitOfWork.FlightBookingRepository.GetById(bookingId);
            if (booking == null || booking.Flight == null || booking.AppUser == null)
                throw new Exception("Invalid booking details");

            var sessionOptions = new SessionCreateOptions
            {
                CustomerEmail = booking.AppUser.Email,
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "inr",
                            UnitAmountDecimal = (decimal?)booking.amount * 100,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = booking.Flight.name,
                                Images = new List<string> { "https://imgak.mmtcdn.com/flights/assets/media/dt/common/icons/AI.png?v=20" },
                            }
                        },
                        Quantity = 1
                    }
                },
                Mode = "payment",
                SuccessUrl = $"http://localhost:5253/api/flightBooking/success?sessionId={{CHECKOUT_SESSION_ID}}&booking_id={bookingId}",
                CancelUrl = "http://localhost:4200/paymentFailure"
            };

            var sessionService = new SessionService();
            return sessionService.Create(sessionOptions);
        }

        public async Task<ResponseFlightPaymentDto> HandleSuccessfulPayment(string sessionId, int bookingId)
        {
            var sessionService = new SessionService();
            var session = sessionService.Get(sessionId);

            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = paymentIntentService.Get(session.PaymentIntentId);

            var chargeService = new ChargeService();
            var charge = chargeService.Get(paymentIntent.LatestChargeId);

            var booking = await _unitOfWork.FlightBookingRepository.GetById(bookingId);
            if (booking == null)
                throw new Exception("Booking not found");

            booking.isBooked = 1;
            booking.paymentId = session.PaymentIntentId;

            var payment = new FlightPayementEntity
            {
                stripe_payement_intent_id = session.PaymentIntentId,
                payement_status = session.PaymentStatus,
                amount = (session.AmountTotal ?? 0) / 100.0,
                FlightBookingId = booking.id,
                sessionId = session.Id,
                card = charge.PaymentMethodDetails.Card.Brand
            };

            await _unitOfWork.StripePayementRepository.SavePaymentAsync(payment);

            await _unitOfWork.CompleteAsync();
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
                    id = booking.id,
                    flight_id = booking.flight_id,
                    user_id = booking.user_id,
                    isBooked = booking.isBooked,
                    amount = booking.amount,
                    no_of_adults = booking.no_of_adults,
                    no_of_children = booking.no_of_children,
                    paymentId = booking.paymentId,
                    Flight=new ResponseFlightDto
                    {
                        date_of_departure=booking.Flight.date_of_departure,
                        destination=booking.Flight.destination,
                        id=booking.flight_id,
                        name=booking.Flight.name,
                        no_of_seats=booking.Flight.no_of_seats,
                        price=booking.Flight.price,
                        seatType=booking.Flight.seatType,
                        source=booking.Flight.source,
                        time_of_arrival=booking.Flight.time_of_arrival,
                        time_of_departure=booking.Flight.time_of_departure,
                        FlightBookings = new List<ResponseFlightBookingDto>()
                    }
                }
            };
            return responseDto;
        }
    }
}
