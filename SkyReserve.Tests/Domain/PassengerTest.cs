public class PassengerTest
{
    [Fact]
    public void Constructor_ShouldThrow_WhenFirstNameIsInvalid()
    {
        // Arrange
        var FirstName = "";
        var LastName = "Doe";
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Passenger(FirstName, LastName));
    }
    [Fact]
    public void Constructor_ShouldThrow_WhenLastNameIsInvalid()
    {
        // Arrange
        var FirstName = "John";
        var LastName = "";
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Passenger(FirstName, LastName));
    }
    [Fact]
    public void Constructor_ShouldCreatePassenger_WhenValidParameters()
    {
        // Arrange
        var FirstName = "John";
        var LastName = "Doe";
        // Act
        var passenger = new Passenger(FirstName, LastName);
        // Assert
        Assert.NotNull(passenger);
        Assert.Equal(FirstName, passenger.FirsName);
        Assert.Equal(LastName, passenger.LastName);
    }
    [Fact]
    public void UpdatePassportNumber_ShouldThrow_WhenPassportNumberIsInvalid()
    {
        // Arrange
        var passenger = new Passenger("John", "Doe");
        var invalidPassportNumber = "";
        // Act & Assert
        Assert.Throws<ArgumentException>(() => passenger.UpdatePassportNumber(invalidPassportNumber));
    }
    [Fact]
    public void UpdatePassportNumber_ShouldUpdatePassportNumber_WhenValidPassportNumber()
    {
        // Arrange
        var passenger = new Passenger("John", "Doe");
        var validPassportNumber = "A12345678";
        // Act
        passenger.UpdatePassportNumber(validPassportNumber);
        // Assert
        Assert.Equal(validPassportNumber, passenger.PassportNumber);
    }
    [Fact] 
    public void GetFullName_ShouldReturnFullName()
    {
        // Arrange
        var passenger = new Passenger("John", "Doe");
        var expectedFullName = "John Doe";
        // Act
        var fullName = passenger.GetFullName();
        // Assert
        Assert.Equal(expectedFullName, fullName);
    }
}