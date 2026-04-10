

public interface ITicketRepository
{
    void Add(Ticket ticket);
    IEnumerable<Ticket> GetAll();
}