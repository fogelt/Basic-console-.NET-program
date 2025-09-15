using System;

public static class ProductPriceWithMethods
{
    const double tax = 0.25; // 25% moms

    public static void Run()
    {
        Console.WriteLine("\nGår in i produktpris med metoder...");
        
        Console.Write("Välj en produkt att köpa: ");
        string product = Console.ReadLine()!;

        Console.Write($"Vad kostar {product}? ");
        if (!double.TryParse(Console.ReadLine(), out double cost) || cost < 0)
        {
            Console.WriteLine("Ogiltigt pris, försök igen.");
            Run();
            return;
        }

        Console.Write("Hur många vill du köpa? ");
        if (!int.TryParse(Console.ReadLine(), out int amount) || amount <= 0)
        {
            Console.WriteLine("Ogiltigt antal, försök igen.");
            Run();
            return;
        }

        double total = CalculateTotal(cost, amount, tax);
        Console.WriteLine($"\nTotalkostnad för {amount} st {product} inklusive moms: {total:F2} kr");
    }

    private static double CalculateTotal(double price, int quantity, double tax = 0.25)
    {
        return (price * quantity) * (1 + tax);
    }
}
