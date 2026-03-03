

public class BookingService
{
    private readonly IFlightRepository _flightRepository;
    private readonly IPaymentService _paymentService;

    private readonly ITicketRepository _ticketRepository;

    public BookingService(IFlightRepository flightRepository, IPaymentService paymentService, ITicketRepository ticketRepository)
    {
        _flightRepository = flightRepository;
        _paymentService = paymentService;
        _ticketRepository = ticketRepository;
    }

    public async Task<Ticket> BookTicketAsync(
        string flightNumber,
        string seatNumber,
        Passenger passenger,
        decimal price)
    {
        var flight = _flightRepository.GetByFlightNumber(flightNumber)
                     ?? throw new InvalidOperationException("Flight not found.");

        var seat = flight.GetSeat(seatNumber);

        if (seat.IsBooked)
            throw new InvalidOperationException("Seat already booked.");

        seat.Book();

        var paymentSuccess = await _paymentService.ProcessPaymentAsync(price);
        
        if (!paymentSuccess)
        {
            seat.Release();
            throw new InvalidOperationException("Payment failed.");
        }

        var ticket = new Ticket(passenger, flight, seat, price);

        _ticketRepository.Add(ticket);

        return ticket;
    }

}