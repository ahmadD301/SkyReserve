

using Domain.Enums;

var flightRepository = new InMemoryFlightRepository();
var ticketRepository = new InMemoryTicketRepository(); 
var paymentService = new FackePaymentService();


var bookingService = new BookingService(flightRepository, paymentService, ticketRepository);

var flight = new Flight("AB123", "New York", "Los Angeles", DateTime.Now.AddDays(1)); 
flight.AddSeat(new Seat("1A", SeatClass.Economy));
flight.AddSeat(new Seat("1B", SeatClass.Economy));
flight.AddSeat(new Seat("1C", SeatClass.Economy));
flight.AddSeat(new Seat("2A", SeatClass.Business));
flight.AddSeat(new Seat("2B", SeatClass.Business));

IEnumerable<Flight> flights = new List<Flight> { flight };
foreach (var f in flights)
{
    flightRepository.Add(f);
}

System.Console.WriteLine("Available flights:");

foreach (var f in flightRepository.GetAll())
{
    System.Console.WriteLine($"{f.FlightNumber}: {f.Origin} to {f.Destination} at {f.DepartureTime}");
}

IEnumerable<Seat> availableSeats = flightRepository.GetAll()
    .SelectMany(f => f.Seats)
    .Where(s => s.IsBooked == false);

System.Console.WriteLine("Available seats:");

foreach (var s in availableSeats){
    System.Console.WriteLine($"{s.SeatNumber} ({s.SeatClass})");
}

var passenger = new Passenger("John", "Doe");
var ticket = await bookingService.BookTicketAsync("AB123", "1A", passenger, 500m);
Console.WriteLine($"Ticket booked successfully for {ticket.Passenger.GetFullName()} on flight {ticket.Flight.FlightNumber}, seat {ticket.Seat.SeatNumber}.");

