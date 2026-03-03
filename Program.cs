using Domain.Enums;

var flight = new Flight("QA123", "Doha", "Paris", DateTime.Now.AddHours(5));
var seat = new Seat("A1", SeatClass.Economy);
flight.AddSeat(seat);

var passenger = new Passenger("Alaa", "Eddin");

seat.Book();

var ticket = new Ticket(passenger, flight, seat, 500);

Console.WriteLine(ticket.Status); // Confirmed

ticket.Cancel();

Console.WriteLine(ticket.Status); // Cancelled
Console.WriteLine(seat.IsBooked); // False