using System;

public static class BMICalculator
{
    public static void Run()
    {
        Console.WriteLine("\n--- BMI Kalkylator ---");
        Console.WriteLine("Välj enhetssystem:");
        Console.WriteLine("1. Metriskt (kg, meter)");
        Console.WriteLine("2. Imperial (pounds, inches)");

        string? unitChoice = Console.ReadLine();
        string unit = unitChoice == "2" ? "imperial" : "metric";

        double weight = AskForDouble(unit == "metric" ? "Ange vikt i kg: " : "Ange vikt i pounds: ");
        double height = AskForDouble(unit == "metric" ? "Ange längd i meter (t.ex. 1,75): " : "Ange längd i inches: ");

        double bmi = CalculateBMI(weight, height, unit);

        Console.WriteLine($"\nDitt BMI är: {bmi:F2}");
        Console.WriteLine($"Kategori: {BMICategory(bmi)}");
    }

    private static double AskForDouble(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out double value) && value > 0)
            {
                return value;
            }
            Console.WriteLine("Ogiltigt värde, försök igen.");
        }
    }

    private static double CalculateBMI(double weight, double height, string unit = "metric")
    {
        if (unit == "metric")
        {
            return weight / (height * height);
        }
        else if (unit == "imperial")
        {
            return 703 * (weight / (height * height));
        }
        else
        {
            Console.WriteLine("Okänd enhet, returnerar 0");
            return 0;
        }
    }

    private static string BMICategory(double bmi)
    {
        if (bmi < 18.5) return "Undervikt";
        if (bmi < 25) return "Normalvikt";
        if (bmi < 30) return "Övervikt";
        return "Fetma";
    }
}
