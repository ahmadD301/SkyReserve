
public class InMemoryFlightRepository : IFlightRepository
{
    private readonly List<Flight> _flights = new();
    public void Add(Flight flight)
    {
        _flights.Add(flight);
    }
    public IEnumerable<Flight> GetAll()
    {
        return _flights;
    }
    public Flight? GetByFlightNumber(string flightNumber)
    {
        return _flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
    }
}