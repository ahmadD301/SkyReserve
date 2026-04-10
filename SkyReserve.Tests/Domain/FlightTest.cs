

using System.Xml.Schema;
using Domain.Enums;

public class FlightTest
{   
    [Fact]
    public void Constructor_ShouldInitializePropertiesCorrectly()
    {
        // Arrange

        string flightNumber = "AA123";
        string origin = "New York";
        string destination = "Los Angeles";
        DateTime departureTime = DateTime.Now.AddHours(1);

        // Act
        var flight = new Flight(flightNumber, origin, destination, departureTime);
        // Assert

        Assert.Equal(flightNumber, flight.FlightNumber);
        Assert.Equal(origin, flight.Origin);
        Assert.Equal(destination, flight.Destination);
        Assert.Equal(departureTime, flight.DepartureTime);
        Assert.Equal(FlightStatus.Scheduled, flight.Status);
    }
    [Fact]
    public void Constructor_ShouldThrow_WhenFlightNumberIsInvalid()
    {
        // Arrange
        string flightNumber = "";
        string origin = "New York";
        string destination = "Los Angeles";
        DateTime departureTime = DateTime.Now.AddHours(1);
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Flight(flightNumber, origin, destination, departureTime));
    }
    [Fact]
    public void Constructor_ShouldThrow_WhenOriginIsInvalid()
    {
        // Arrange
        string flightNumber = "AA123";
        string origin = "";
        string destination = "Los Angeles";
        DateTime departureTime = DateTime.Now.AddHours(1);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Flight(flightNumber, origin, destination, departureTime));
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenDestinationIsInvalid()
    {
        // Arrange
        string flightNumber = "AA123";
        string origin = "New York";
        string destination = "";
        DateTime departureTime = DateTime.Now.AddHours(1);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Flight(flightNumber, origin, destination, departureTime));
    }
    [Fact]
    public void Constructor_ShouldThrow_WhenDepartureTimeIsInThePast()
    {
        // Arrange
        string flightNumber = "AA123";
        string origin = "New York";
        string destination = "Los Angeles";
        DateTime departureTime = DateTime.Now.AddHours(-1);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Flight(flightNumber, origin, destination, departureTime));
    }

    [Fact]
    public void AddSeat_ShouldAddSeatToFlight_WhenSeatIsAvailable()
    {
        // Arrange

        var flight = new Flight("AA123", "New York", "Los Angeles", DateTime.Now.AddHours(1));
        var seat = new Seat("1A", SeatClass.Economy);

        // Act
        flight.AddSeat(seat);   
        // Assert

        Assert.Contains(seat, flight.Seats);
    }
    [Fact]
    public void AddSeat_ShouldThrow_WhenSeatIsNull()
    {
        // Arrange

        var flight = new Flight("AA123", "New York", "Los Angeles", DateTime.Now.AddHours(1));
        Seat seat = null;

        // Act & Assert

        Assert.Throws<ArgumentNullException>(() => flight.AddSeat(seat));
    }
    [Fact]
    public void AddSeat_ShouldThrow_WhenSeatAlreadyExists()
    {
        // Arrange

        var flight = new Flight("AA123", "New York", "Los Angeles", DateTime.Now.AddHours(1));
        var seat = new Seat("1A", SeatClass.Economy);
        flight.AddSeat(seat);

        // Act & Assert

        Assert.Throws<ArgumentException>(() => flight.AddSeat(seat));
    }
    [Fact]
    public void GetSeat_ShouldReturnSeat_WhenSeatExists()
    {
        // Arrange

        var flight = new Flight("AA123", "New York", "Los Angeles", DateTime.Now.AddHours(1));
        var seat = new Seat("1A", SeatClass.Economy);
        flight.AddSeat(seat);

        // Act
        var result = flight.GetSeat("1A");

        // Assert

        Assert.Equal(seat, result);
    }
    [Fact]
    public void GetSeat_ShouldThrow_WhenSeatDoesNotExist()
    {
        // Arrange

        var flight = new Flight("AA123", "New York", "Los Angeles", DateTime.Now.AddHours(1));

        // Act & Assert

        Assert.Throws<ArgumentException>(() => flight.GetSeat("1A"));
    }

    [Fact]
    public void CancelFlight_ShouldChangeStatusToCancelled()
    {
        // Arrange

        var flight = new Flight("AA123", "New York", "Los Angeles", DateTime.Now.AddHours(1));

        // Act
        flight.CancelFlight();

        // Assert

        Assert.Equal(FlightStatus.Cancelled, flight.Status);
    }
    [Fact]
    public void CancelFlight_ShouldThrow_WhenFlightIsAlreadyCancelled()
    {
        // Arrange

        var flight = new Flight("AA123", "New York", "Los Angeles", DateTime.Now.AddHours(1));
        flight.CancelFlight();

        // Act & Assert

        Assert.Throws<InvalidOperationException>(() => flight.CancelFlight());
    }
    [Fact]
    public void GetAvailableSeats_ShouldReturnOnlyAvailableSeats()
    {
        // Arrange

        var flight = new Flight("AA123", "New York", "Los Angeles", DateTime.Now.AddHours(1));
        var seat1 = new Seat("1A", SeatClass.Economy);
        var seat2 = new Seat("1B", SeatClass.Economy);
        seat2.Book();
        flight.AddSeat(seat1);
        flight.AddSeat(seat2);

        // Act
        var availableSeats = flight.GetAvailableSeats();

        // Assert

        Assert.Contains(seat1, availableSeats);
        Assert.DoesNotContain(seat2, availableSeats);
    }
    [Fact]
    public void GetAvailableSeats_ShouldReturnEmptyList_WhenNoSeatsAreAvailable()
    {
        // Arrange

        var flight = new Flight("AA123", "New York", "Los Angeles", DateTime.Now.AddHours(1));
        var seat1 = new Seat("1A", SeatClass.Economy);
        var seat2 = new Seat("1B", SeatClass.Economy);
        seat1.Book();
        seat2.Book();
        flight.AddSeat(seat1);
        flight.AddSeat(seat2);

        // Act
        var availableSeats = flight.GetAvailableSeats();
        // Assert

        Assert.Empty(availableSeats);
    }
}

