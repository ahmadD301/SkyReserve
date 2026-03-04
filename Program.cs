using AirportBookingSystem.Presentation.Menus;
using Domain.Enums;

var flightRepository = new InMemoryFlightRepository();
var ticketRepository = new InMemoryTicketRepository();
var paymentService = new FackePaymentService();

var bookingService = new BookingService(
    flightRepository,
    paymentService,
    ticketRepository);

// Seed data
var flight = new Flight("QA123", "Doha", "Paris", DateTime.Now.AddHours(5));
flight.AddSeat(new Seat("A1", SeatClass.Economy));
flight.AddSeat(new Seat("A2", SeatClass.Economy));
flight.AddSeat(new Seat("B1", SeatClass.Business));
flightRepository.Add(flight);

var mainMenu = new MainMenu(bookingService);

await mainMenu.StartAsync();