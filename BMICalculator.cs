using System;

public static class BMICalculator
{

    public static void Run()
    {
        CalculateBMI(0, 0, "metric");
    }
    static double CalculateBMI(double weight, double height, string unit = "metric")
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
}