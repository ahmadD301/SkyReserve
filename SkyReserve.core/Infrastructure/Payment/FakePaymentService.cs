
public class FackePaymentService : IPaymentService
{
    public async Task<bool> ProcessPaymentAsync(decimal amount)
    {
        System.Console.WriteLine($"Processing payment of {amount:C}...");

        await Task.Delay(2000); // Simulate some delay
        
        System.Console.WriteLine("Payment processed successfully.");
        return true;
    }
}