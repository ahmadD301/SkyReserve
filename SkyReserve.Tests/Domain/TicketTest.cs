
using System;
using Domain.Enums;
using Xunit;
public class TicketTest
{
    [Fact]
    public void Constructor_InitializesPropertiesCorrectly()
    {
        // Arrange
        var passenger = new Passenger("John Doe", "Smith");
        var flight = new Flight("AB123", "New York", "Los Angeles", DateTime.UtcNow.AddDays(1));
        var seat = new Seat("12A", SeatClass.Economy);
        seat.Book(); // Book the seat before creating the ticket
        // Act
        var ticket = new Ticket(passenger, flight, seat , 199.99m);

        // Assert
        Assert.Equal(passenger, ticket.Passenger);
        Assert.Equal(flight, ticket.Flight);
        Assert.Equal(seat, ticket.Seat);
        Assert.Equal(199.99m, ticket.Price);
    }
    [Fact]
    public void Constructor_ThrowsException_WhenSeatIsNotBooked()
    {
        // Arrange
        var passenger = new Passenger("John Doe", "Smith");
        var flight = new Flight("AB123", "New York", "Los Angeles", DateTime.UtcNow.AddDays(1));
        var seat = new Seat("12A", SeatClass.Economy);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => new Ticket(passenger, flight, seat, 199.99m));
    }
    [Fact]
    public void Constructor_ThrowsException_WhenPriceIsNegative()
    {
        // Arrange
        var passenger = new Passenger("John Doe", "Smith");
        var flight = new Flight("AB123", "New York", "Los Angeles", DateTime.UtcNow.AddDays(1));
        var seat = new Seat("12A", SeatClass.Economy);
        seat.Book(); 

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Ticket(passenger, flight, seat, -50m));    
    }
    [Fact]
    public void Cancel_ChangesStatusToCancelled()
    {
        // Arrange
        var passenger = new Passenger("John Doe", "Smith");
        var flight = new Flight("AB123", "New York", "Los Angeles", DateTime.UtcNow.AddDays(1));
        var seat = new Seat("12A", SeatClass.Economy);
        seat.Book(); 
        var ticket = new Ticket(passenger, flight, seat, 199.99m);

        // Act
        ticket.Cancel();

        // Assert
        Assert.Equal(TicketStatus.Cancelled, ticket.Status);
        Assert.False(seat.IsBooked);
    }
    [Fact]
    public void Cancel_ThrowsException_WhenTicketIsAlreadyCancelled()
    {
        // Arrange
        var passenger = new Passenger("John Doe", "Smith");
        var flight = new Flight("AB123", "New York", "Los Angeles", DateTime.UtcNow.AddDays(1));
        var seat = new Seat("12A", SeatClass.Economy);
        seat.Book(); 
        var ticket = new Ticket(passenger, flight, seat, 199.99m);
        ticket.Cancel();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => ticket.Cancel());
    }
}