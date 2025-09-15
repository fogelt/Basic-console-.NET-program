using System;

public static class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--Välj program--");
            Console.WriteLine("1. Hälsa användaren");
            Console.WriteLine("2. Enkel Miniräknare");
            Console.WriteLine("3. Produktpris med metoder");
            Console.WriteLine("4. BMI Kalkylator");
            Console.WriteLine("5. Metodövarlagring");
            Console.WriteLine("6. Biobokaren");
            Console.Write("--skriv 'exit' för att avsluta--");
            string input = Console.ReadLine()!;

            if (input.ToLower() == "exit")
                break;

            switch (input)
            {
                case "1":
                    HelloUser.Run();
                    break;
                case "2":
                    SimpleCalculator.Run();
                    break;
                case "3":
                    ProductPriceWithMethods.Run();
                    break;
                case "4":
                   // BMICalculator.Run();
                    break;
                case "5":
                   // MethodPracticeStorage.Run();
                    break;
                case "6":
                  //  MovieBooking.Run();
                    break;
                default:
                    Console.WriteLine("Number not recognized.");
                    break;
            }
        }
    }       
}