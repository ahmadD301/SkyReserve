


public class BookingMenu
{
    private readonly BookingService _bookingService;
    public BookingMenu(BookingService bookingService)
    {
        _bookingService = bookingService;
    }
    public async Task BookTicketAsync()
    {
        ConsoleHelper.PrintHeader("Book a Ticket");

        var flightNumber = ConsoleHelper.ReadRequiredString("Flight Number: ");
        var seatNumber = ConsoleHelper.ReadRequiredString("Seat Number: ");
        var firstName = ConsoleHelper.ReadRequiredString("First Name: ");
        var lastName = ConsoleHelper.ReadRequiredString("Last Name: ");

        var passenger = new Passenger(firstName, lastName);

        try
        {
            var ticket = await _bookingService.BookTicketAsync(flightNumber, seatNumber, passenger, 500m);
            Console.WriteLine($"Ticket booked successfully for {ticket.Passenger.GetFullName()} on flight {ticket.Flight.FlightNumber}, seat {ticket.Seat.SeatNumber}.");

            Console.WriteLine();
            Console.WriteLine("Ticket booked successfully!");
            Console.WriteLine($"Passenger: {ticket.Passenger.GetFullName()}");
            Console.WriteLine($"Flight: {ticket.Flight.FlightNumber}");
            Console.WriteLine($"Seat: {ticket.Seat.SeatNumber}");
            Console.WriteLine($"Price: {ticket.Price}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("An error occurred while booking the ticket: " + ex.Message);
        }
    }
}