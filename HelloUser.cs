using System;

public static class HelloUser
{

    public static void Run()
    {
        SayHello();
    }
    static void SayHello()
    {
        Console.Write("\nSkriv ditt namn: ");
        string name = Console.ReadLine()!;
        Console.WriteLine($"Hej {name}, välkommen till programmet!");
        Program.Main();
    }
}