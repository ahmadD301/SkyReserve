using System.Security.Cryptography.X509Certificates;

public class Passenger
{
    public Guid Id { get; }
    public string FirsName { get; private set; }
    public string LastName { get; private set; }
    public string? PassportNumber { get; private set; }
    public DateTime? DateOfBirth { get; private set; }

    public Passenger(string firstName, string lastName, string? passportNumber = null, DateTime? dateOfBirth = null)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name cannot be null or empty.", nameof(firstName));
        }
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name cannot be null or empty.", nameof(lastName));
        }

        Id = Guid.NewGuid();
        FirsName = firstName;
        LastName = lastName;
        PassportNumber = passportNumber;
        DateOfBirth = dateOfBirth;
    }
    public void UpdatePassportNumber(string passportNumber)
    {
        if (string.IsNullOrWhiteSpace(passportNumber))
        {
            throw new ArgumentException("Passport number cannot be null or empty.", nameof(passportNumber));
        }
        PassportNumber = passportNumber;
    }
    public string GetFullName()
    {
        return $"{FirsName} {LastName}";
    }
}