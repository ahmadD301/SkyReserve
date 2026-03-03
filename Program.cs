var passenger = new Passenger("John", "Smith");
System.Console.WriteLine(passenger.GetFullName());
passenger.UpdatePassportNumber("123456789");
System.Console.WriteLine($"Passenger {passenger.GetFullName()} has passport number: {passenger.PassportNumber}");
