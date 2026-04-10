

public class Ticket
{
    public Guid Id { get; }
    public Passenger Passenger { get; }
    public Flight Flight { get; }
    public Seat Seat { get; }
    public decimal Price { get; }
    public DateTime BookingDate { get; }
    public TicketStatus Status { get; private set; }

public Ticket(Passenger passenger, Flight flight, Seat seat, decimal price)
    {
        if(price < 0)
        {
            throw new ArgumentException("Price cannot be negative.", nameof(price));
        }
        if(!seat.IsBooked)
        {
            throw new InvalidOperationException("Seat must be booked before creating a ticket.");
        }

        Id = Guid.NewGuid();
        Passenger = passenger ?? throw new ArgumentNullException(nameof(passenger));
        Flight = flight ?? throw new ArgumentNullException(nameof(flight));
        Seat = seat ?? throw new ArgumentNullException(nameof(seat));
        Price = price;
        BookingDate = DateTime.UtcNow;
        Status = TicketStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status == TicketStatus.Cancelled)
        {
            throw new InvalidOperationException("Ticket is already cancelled.");
        }
        Status = TicketStatus.Cancelled;
        Seat.Release();
    }
    
}