
using Domain.Enums;

var flight = new Flight("AA123", "New York", "Los Angeles", DateTime.Now.AddHours(5));

flight.AddSeat(new Seat("1A", SeatClass.Economy));
flight.AddSeat(new Seat("1B", SeatClass.Economy));
flight.AddSeat(new Seat("1C", SeatClass.Business));
Console.WriteLine($"Flight {flight.FlightNumber} from {flight.Origin} to {flight.Destination} departs at {flight.DepartureTime}");

IEnumerable<Seat> availableSeats = flight.Seats.Where(s => s.IsBooked == false);
Console.WriteLine("Available seats:");
foreach (var seat in availableSeats)
{
    Console.WriteLine($" - {seat.SeatNumber} ({seat.SeatClass})");
}

var seat1 = flight.GetSeat("1A");
seat1.Book();
Console.WriteLine($"Seat {seat1.SeatNumber} is now booked.");

Console.WriteLine("Available seats:");
foreach (var seat in availableSeats)
{
    Console.WriteLine($" - {seat.SeatNumber} ({seat.SeatClass})");
}

