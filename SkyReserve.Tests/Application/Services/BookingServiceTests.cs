using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Domain.Enums;
public class BookingServiceTests
{
    [Fact]
    public async Task BookTicketAsync_ShouldReturnTrue_WhenBookingIsSuccessful()
    {
        // Arrange
        var flightRepositoryMock = new Mock<IFlightRepository>();
        var paymentServiceMock = new Mock<IPaymentService>();
        var ticketRepositoryMock = new Mock<ITicketRepository>();

        var seat = new Seat("A1" , SeatClass.Economy);
        var flight = new Flight("FL123", "NYC", "LAX", DateTime.Now.AddDays(1));
        var passenger = new Passenger("John Doe", "Smith" , "123456789", new DateTime(1990, 1, 1));

        flight.AddSeat(seat);

        flightRepositoryMock.Setup(repo => repo.GetByFlightNumber("FL123"))
        .Returns(flight);

        paymentServiceMock.Setup(service => service.ProcessPaymentAsync(It.IsAny<decimal>()))
        .ReturnsAsync(true);

        var service = new BookingService(
            flightRepositoryMock.Object, 
            paymentServiceMock.Object, 
            ticketRepositoryMock.Object
        );

        // Act
        string seatNumber = seat.SeatNumber;
        var ticket = await service.BookTicketAsync("FL123", seatNumber, passenger, 100m);
    
        // Assert
        Assert.NotNull(ticket);
        Assert.True(seat.IsBooked);
        ticketRepositoryMock.Verify(repo => repo.Add(It.IsAny<Ticket>()), Times.Once);
    }

   [Fact] 
    public async Task BookTicketAsync_ShouldThrowException_WhenSeatIsAlreadyBooked()
    {
        // Arrange
        var seat = new Seat("A1" , SeatClass.Economy);
        seat.Book();

        var flight = new Flight("FL123", "NYC", "LAX", DateTime.Now.AddDays(1));
        flight.AddSeat(seat);

        var flightRepositoryMock = new Mock<IFlightRepository>();
        var paymentServiceMock = new Mock<IPaymentService>();
        var ticketRepositoryMock = new Mock<ITicketRepository>();
        
        flightRepositoryMock.Setup(repo => repo.GetByFlightNumber("FL123"))
        .Returns(flight);

        var passenger = new Passenger("John Doe", "Smith" , "123456789", new DateTime(1990, 1, 1));
        // Act & Assert
        var service = new BookingService(
            flightRepositoryMock.Object, 
            paymentServiceMock.Object, 
            ticketRepositoryMock.Object
        );

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => 
            service.BookTicketAsync("FL123", "A1", passenger, 100m)
        );

        Assert.Equal("Seat already booked.", exception.Message);
    }

    [Fact]
    public async Task BookTicketAsync_ShouldThrowException_WhenFlightIsNotFound()
    {
        // Arrange
        var seat = new Seat("A1" , SeatClass.Economy);
  

        var flightRepositoryMock = new Mock<IFlightRepository>();
        var paymentServiceMock = new Mock<IPaymentService>();
        var ticketRepositoryMock = new Mock<ITicketRepository>();

        flightRepositoryMock.Setup(repo => repo.GetByFlightNumber("FL123"))
        .Returns((Flight)null);
        // Act
        var service = new BookingService(
            flightRepositoryMock.Object, 
            paymentServiceMock.Object, 
            ticketRepositoryMock.Object
        );
        var passenger = new Passenger("John Doe", "Smith" , "123456789", new DateTime(1990, 1, 1));
        
        // Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => 
            service.BookTicketAsync("FL123", "A1", passenger, 100m)
        );
        Assert.Equal("Flight not found.", exception.Message);
    }
    [Fact]
    public async Task BookTicketAsync_ShouldThrowException_WhenPaymentFails()
    {
        // Arrange
        var seat = new Seat("A1" , SeatClass.Economy);
        var flight = new Flight("FL123", "NYC", "LAX", DateTime.Now.AddDays(1));
        var passenger = new Passenger("John Doe", "Smith" , "123456789", new DateTime(1990, 1, 1));

        var flightRepositoryMock = new Mock<IFlightRepository>();
        var paymentServiceMock = new Mock<IPaymentService>();
        var ticketRepositoryMock = new Mock<ITicketRepository>();
        flight.AddSeat(seat);
        flightRepositoryMock.Setup(repo => repo.GetByFlightNumber("FL123"))
        .Returns(flight);

        paymentServiceMock.Setup(service => service.ProcessPaymentAsync(It.IsAny<decimal>()))
        .ReturnsAsync(false);

        // Act & Assert
        var service = new BookingService(
            flightRepositoryMock.Object, 
            paymentServiceMock.Object, 
            ticketRepositoryMock.Object
        );
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => 
            service.BookTicketAsync("FL123", "A1", passenger, 100m)
        );
        Assert.Equal("Payment failed.", exception.Message);

    }
}