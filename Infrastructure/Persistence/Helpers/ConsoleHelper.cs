

public static class ConsoleHelper
{
    public static string ReadRequiredString(string message)
    {
        string? input;
        do
        {
            Console.Write(message);
            input = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }
    public static int ReadInt(string message)
    {
        int result;
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out result))// Try to parse the input as an integer
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
        return result;
    }
        public static void PrintHeader(string title)
    {
        Console.Clear();
        Console.WriteLine("=====================================");
        Console.WriteLine(title.ToUpper());
        Console.WriteLine("=====================================");
    }

}