namespace AirportBookingSystem.Presentation.Menus;

public class MainMenu
{
    private readonly BookingService _bookingService;

    public MainMenu(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task StartAsync()
    {
        while (true)
        {
            ConsoleHelper.PrintHeader("Airport Booking System");

            Console.WriteLine("1. Book Ticket");
            Console.WriteLine("2. Exit");

            var choice = ConsoleHelper.ReadInt("Select option: ");

            switch (choice)
            {
                case 1:
                    var bookingMenu = new BookingMenu(_bookingService);
                    await bookingMenu.BookTicketAsync();
                    break;

                case 2:
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}