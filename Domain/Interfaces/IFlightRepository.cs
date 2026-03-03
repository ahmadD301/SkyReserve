

public interface IFlightRepository
{
    Flight? GetByFlightNumber(string flightNumber);
    IEnumerable<Flight> GetAll();
    void Add(Flight flight);
}
