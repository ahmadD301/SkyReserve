


using Domain.Enums;

public class Seat
{
    public string SeatNumber { get;  }
    public SeatClass SeatClass { get;  }
    public bool IsBooked { get; private set; }

    public Seat(string seatNumber, SeatClass seatClass)
    {   
        if (string.IsNullOrWhiteSpace(seatNumber))
        {
            throw new ArgumentException("Seat number cannot be null or empty.", nameof(seatNumber));
        }
        if (!Enum.IsDefined(typeof(SeatClass), seatClass))
        {
            throw new ArgumentException("Invalid seat class.", nameof(seatClass));
        }
        SeatNumber = seatNumber;
        SeatClass = seatClass;
        IsBooked = false;
    }

    public void Book()
    {
        if (IsBooked)
        {
            throw new InvalidOperationException($"Seat {SeatNumber} is already booked.");
        }
        IsBooked = true;
    }
    public void Release()
    {
        if (!IsBooked)
        {
            throw new InvalidOperationException($"Seat {SeatNumber} is not booked.");
        }
        IsBooked = false;
    }

}