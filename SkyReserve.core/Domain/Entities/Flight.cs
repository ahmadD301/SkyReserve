using Domain.Enums;
public class Flight
{   
    public readonly List<Seat> _seats = new();
    public string FlightNumber { get; }
    public string Origin { get; }
    public string Destination { get; }
    public DateTime DepartureTime { get; }
    public FlightStatus Status { get; private set; }

    public IReadOnlyCollection<Seat> Seats => _seats.AsReadOnly();

    public Flight(string flightNumber, string origin, string destination, DateTime departureTime)
    {
        if (string.IsNullOrWhiteSpace(flightNumber))
        {
            throw new ArgumentException("Flight number cannot be null or empty.", nameof(flightNumber));
        }
        if (string.IsNullOrWhiteSpace(origin))
        {
            throw new ArgumentException("Origin cannot be null or empty.", nameof(origin));
        }
        if (string.IsNullOrWhiteSpace(destination))
        {
            throw new ArgumentException("Destination cannot be null or empty.", nameof(destination));
        }
        if (departureTime <= DateTime.Now)
        {
            throw new ArgumentException("Departure time must be in the future.", nameof(departureTime));
        }

        FlightNumber = flightNumber;
        Origin = origin;
        Destination = destination;
        DepartureTime = departureTime;
        Status = FlightStatus.Scheduled;
    }
    public void AddSeat(Seat seat)
    {
        if (seat == null)
        {
            throw new ArgumentNullException(nameof(seat), "Seat cannot be null.");
        }
        if (_seats.Any(s => s.SeatNumber == seat.SeatNumber))
        {
            throw new ArgumentException($"Seat with number {seat.SeatNumber} already exists on this flight.", nameof(seat));
        }
        _seats.Add(seat);
    }
    public Seat GetSeat(string seatNumber)
    {   
        var seat = _seats.FirstOrDefault(s => s.SeatNumber == seatNumber);
        if (seat == null)
        {
            throw new ArgumentException("Seat number cannot be null or empty.", nameof(seatNumber));
        }
        return seat;
    }
    public void CancelFlight()
    {
        if (Status == FlightStatus.Cancelled)
        {
            throw new InvalidOperationException($"Flight {FlightNumber} is already cancelled.");
        }
        Status = FlightStatus.Cancelled;
    }

    public IEnumerable<Seat> GetAvailableSeats()
    {
        return _seats.Where(s => !s.IsBooked);
    }
}