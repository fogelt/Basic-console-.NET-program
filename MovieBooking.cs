using System;

public static class MovieBooking
{
    // Globalt "state" för bokningen
    private static double StudentDiscount = 0.15;
    private static string? SelectedMovie;
    private static string? SelectedShowtime;
    private static int Tickets = 0;

    public static void Run()
    {
        const double TAX_RATE = 0.06;   // 6% moms
        const string CURRENCY = "SEK";

        string[] movies = { "Inception", "The Matrix", "Interstellar", "The Dark Knight" };
        string[] showtimes = { "12:00", "15:00", "18:00", "21:00" };
        double base_price = 100.0;

        Console.WriteLine("\n--- Biobokaren ---");
        Console.WriteLine("1. Lista filmer");
        Console.WriteLine("2. Välj film & tid, ange biljetter");
        Console.WriteLine("3. Lägg på/ta bort studentrabatt");
        Console.WriteLine("4. Skriv ut kvitto");
        Console.WriteLine("5. Avsluta");

        if (!int.TryParse(Console.ReadLine(), out int user_input) || user_input <= 0)
        {
            Console.WriteLine("Ogiltigt val, försök igen.");
            Run();
            return;
        }

        switch (user_input)
        {
            case 1:
                ListMovies(movies, showtimes);
                break;
            case 2:
                ChooseMovie(movies, showtimes, base_price, TAX_RATE, CURRENCY);
                break;
            case 3:
                ToggleStudentDiscount();
                break;
            case 4:
                PrintReceipt(base_price, TAX_RATE, StudentDiscount, CURRENCY);
                break;
            case 5:
                Console.WriteLine("Tack för att du använde Biobokaren!");
                return;
            default:
                Console.WriteLine("Ogiltigt val, försök igen.");
                Run();
                return;
        }
    }

    private static void ListMovies(string[] movies, string[] showtimes)
    {
        Console.WriteLine("\nTillgängliga filmer och tider:");
        for (int i = 0; i < movies.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {movies[i]} - Tider: {string.Join(", ", showtimes)}");
        }
        Run();
    }

    private static void ChooseMovie(string[] movies, string[] showtimes, double base_price, double tax, string currency)
    {
        Console.WriteLine("\nVälj en film (ange nummer):");
        for (int i = 0; i < movies.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {movies[i]}");
        }

        if (!int.TryParse(Console.ReadLine(), out int movieChoice) || movieChoice < 1 || movieChoice > movies.Length)
        {
            Console.WriteLine("Ogiltigt val.");
            Run();
            return;
        }

        SelectedMovie = movies[movieChoice - 1];

        Console.WriteLine("\nVälj en tid (ange nummer):");
        for (int i = 0; i < showtimes.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {showtimes[i]}");
        }

        if (!int.TryParse(Console.ReadLine(), out int timeChoice) || timeChoice < 1 || timeChoice > showtimes.Length)
        {
            Console.WriteLine("Ogiltigt val.");
            Run();
            return;
        }

        SelectedShowtime = showtimes[timeChoice - 1];

        Console.WriteLine("\nHur många biljetter vill du köpa?");
        if (!int.TryParse(Console.ReadLine(), out int ticketCount) || ticketCount <= 0)
        {
            Console.WriteLine("Ogiltigt antal.");
            Run();
            return;
        }

        Tickets = ticketCount;

        Console.WriteLine($"\nDu har valt {Tickets} biljetter till '{SelectedMovie}' kl {SelectedShowtime}.");
        Run();
    }

    private static void ToggleStudentDiscount()
    {
        StudentDiscount = StudentDiscount > 0 ? 0 : 0.15;
        Console.WriteLine(StudentDiscount > 0 ? "Studentrabatt aktiverad." : "Studentrabatt borttagen.");
        Run();
    }

    private static void PrintReceipt(double price, double tax, double discount, string currency)
    {
        if (string.IsNullOrEmpty(SelectedMovie) || string.IsNullOrEmpty(SelectedShowtime) || Tickets == 0)
        {
            Console.WriteLine("Ingen bokning har gjorts ännu!");
            Run();
            return;
        }

        double subtotal = price * Tickets;
        double discountAmount = subtotal * discount;
        double taxed = (subtotal - discountAmount) * (1 + tax);

        Console.WriteLine("\n--- Kvitto ---");
        Console.WriteLine($"Film: {SelectedMovie}");
        Console.WriteLine($"Tid: {SelectedShowtime}");
        Console.WriteLine($"Antal biljetter: {Tickets}");
        Console.WriteLine($"Pris per biljett: {price:F2} {currency}");
        if (discount > 0)
            Console.WriteLine($"Studentrabatt: -{discountAmount:F2} {currency}");
        Console.WriteLine($"Moms (6%): {(tax * 100):F0}%");
        Console.WriteLine($"Totalt: {taxed:F2} {currency}");
        Console.WriteLine("---------------");

        Run();
    }
}
