using Domain;
using Domain.Enums;

public class SeatTest
{
    [Fact]
    public void Constructor_InitializesPropertiesCorrectly()
    {
        // Arrange 
        var seatNumber = "1A";
        var seatClass = SeatClass.Economy;

        // Act
        var seat = new Seat(seatNumber, seatClass);

        // Assert
        Assert.Equal(seatNumber, seat.SeatNumber);
        Assert.Equal(seatClass, seat.SeatClass);
    }

    [Fact]
    public void Constructor_ThrowsException_WhenSeatNumberIsNullOrEmpty()
    {
        // Arrange
        string seatNumber = null;
        var seatClass = SeatClass.Economy;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Seat(seatNumber, seatClass));
    }

    [Fact]
    public void Constructor_ThrowsException_WhenSeatClassIsInvalid()
    {
        // Arrange
        var seatNumber = "1A";
        var invalidSeatClass = (SeatClass)999; // Invalid enum value

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Seat(seatNumber, invalidSeatClass));
    }
    [Fact]
    public void Book_ShouldSetIsBookedToTrue_WhenSeatIsAvailable()
    {
        // Arrange
        var seat = new Seat("1A", SeatClass.Economy);

        // Act
        seat.Book();

        // Assert
        Assert.True(seat.IsBooked);
    }
    [Fact]
    public void Book_ThrowsException_WhenSeatIsAlreadyBooked()
    {
        // Arrange
        var seat = new Seat("1A", SeatClass.Economy);
        seat.Book();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => seat.Book());
    }
    [Fact]
    public void Release_ShouldSetIsBookedToFalse_WhenSeatIsBooked()
    {
        // Arrange
        var seat = new Seat("1A", SeatClass.Economy);
        seat.Book();

        // Act
        seat.Release();

        // Assert
        Assert.False(seat.IsBooked);
    }
    [Fact]
    public void Release_ThrowsException_WhenSeatIsNotBooked()
    {
        // Arrange
        var seat = new Seat("1A", SeatClass.Economy);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => seat.Release());
    }
}
