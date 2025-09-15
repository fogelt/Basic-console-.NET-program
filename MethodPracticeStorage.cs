using System;

public static class MethodPracticeStorage
{

    public static void Run()
    {
        Console.WriteLine("");
        Console.WriteLine(FormatName("Anna", "Svensson"));
        Console.WriteLine(FormatName("Anna", "Maria", "Svensson"));
        Console.WriteLine(FormatName("Anna", "Svensson", true));
    }
    static string FormatName(string first, string last)
    {
        return $"{first} {last}";
    }

    static string FormatName(string first, string middle, string last)
    {
        return $"{first} {middle} {last}";
    }

    static string FormatName(string first, string last, bool uppercase)
    {
        var full = $"{first} {last}";
        return uppercase ? full.ToUpper() : full;
    }

}