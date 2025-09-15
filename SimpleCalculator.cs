using System;

public static class SimpleCalculator
{
    public static void Run()
    {
        StartCalculator();
    }

    private static void StartCalculator()
    {
        Console.WriteLine("\nGår in i miniräknaren...");
        Console.WriteLine("Välj en operation: ");
        Console.WriteLine("1. Addition (+)");
        Console.WriteLine("2. Subtraktion (-)");
        Console.WriteLine("3. Multiplikation (*)");
        Console.WriteLine("4. Division (/)");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Ogiltigt val, försök igen.");
            StartCalculator();
            return;
        }

        Console.Write("Ange första talet: ");
        if (!int.TryParse(Console.ReadLine(), out int x))
        {
            Console.WriteLine("Ogiltigt tal, försök igen.");
            StartCalculator();
            return;
        }

        Console.Write("Ange andra talet: ");
        if (!int.TryParse(Console.ReadLine(), out int y))
        {
            Console.WriteLine("Ogiltigt tal, försök igen.");
            StartCalculator();
            return;
        }

        switch (choice)
        {
            case 1:
                Console.WriteLine($"\nSvaret är: {Add(x, y)}");
                break;
            case 2:
                Console.WriteLine($"\nSvaret är: {Subtract(x, y)}");
                break;
            case 3:
                Console.WriteLine($"\nSvaret är: {Multiply(x, y)}");
                break;
            case 4:
                if (y == 0)
                    Console.WriteLine("Fel: Division med noll är inte tillåten.");
                else
                    Console.WriteLine($"\nSvaret är: {Divide(x, y)}");
                break;
            default:
                Console.WriteLine("Ogiltigt val");
                break;
        }
    }

    private static int Add(int a, int b) => a + b;
    private static int Subtract(int a, int b) => a - b;
    private static int Multiply(int a, int b) => a * b;
    private static double Divide(int a, int b) => (double)a / b;
}
