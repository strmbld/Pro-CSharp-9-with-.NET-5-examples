using System;
using SimpleGC;

Console.WriteLine("***** GC *****");

Car c = new("Zippy", 50);
Console.WriteLine(c.ToString());

Console.WriteLine($"GetTotalMemory: {GC.GetTotalMemory(false)}");
Console.WriteLine($"Generations: {GC.MaxGeneration}");

Car refToC = new("Zippy", 100);
Console.WriteLine(refToC.ToString());
Console.WriteLine($"Object generation: {GC.GetGeneration(refToC)}");

GC.Collect();
GC.WaitForPendingFinalizers();

Console.WriteLine($"GetTotalMemory: {GC.GetTotalMemory(false)}");

