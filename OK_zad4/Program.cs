using System;
using Microsoft.Z3;


Console.WriteLine("Uruchamiam solver SMT...");
SMT.Solve();

Console.WriteLine("Uruchamiam solver brute-force...");
BruteForce.Solve();