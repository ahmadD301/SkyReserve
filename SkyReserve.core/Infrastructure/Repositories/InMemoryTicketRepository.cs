
public class InMemoryTicketRepository : ITicketRepository
{
    private readonly List<Ticket> _tickets = new();
    public void Add(Ticket ticket)
    {
        _tickets.Add(ticket);
    }

    public IEnumerable<Ticket> GetAll()
    {
        return _tickets;
    }
}