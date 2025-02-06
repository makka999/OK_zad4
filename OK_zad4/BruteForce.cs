using System;
using Microsoft.Z3;

public static class BruteForce
{
    public static void Solve()
    {
        int x6 = 144; // x6 podana w zadaniu

        // poszukiwanie dodatniego x1 x2 x3
        for (int x1 = 1; x1 <= 20; x1++)
        {
            for (int x2 = 1; x2 <= 20; x2++)
            {
                for (int x3 = 1; x3 <= 20; x3++)
                {
                    int x4 = x3 * (x2 + x1);
                    int x5 = x4 * (x3 + x2);

                    if (x5 == 0 || x4 == 0)
                        continue;

                    if (x6 == x5 * (x4 + x3)) // test rekurencyjny
                    {
                        int x7 = x6 * (x5 + x4);

                        Console.WriteLine($"Rozwiązania:");
                        Console.WriteLine($"x1 = {x1}, x2 = {x2}, x3 = {x3}");
                        Console.WriteLine($"x4 = {x4}, x5 = {x5}, x6 = {x6}, x7 = {x7}");
                        return; // zatrzymujemy program po znalezieniu pierwszego rozwiązania
                    }
                }
            }
        }

        Console.WriteLine("Brak rozwiązania spełniającego warunki.");
    }
}
