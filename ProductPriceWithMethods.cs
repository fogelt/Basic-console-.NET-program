using System;

public static class ProductPriceWithMethods
{

    public static void Run()
    {
        CalculateTotal("Produkt", 100.0, 2);
    }
    static double CalculateTotal(string product, double price, int quantity, double tax = 0.25)
    {
        double total = (price * quantity) * (1 + tax);
        return total;
    }   
}