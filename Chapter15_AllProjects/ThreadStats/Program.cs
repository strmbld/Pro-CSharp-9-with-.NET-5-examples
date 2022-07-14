using System;
using System.Threading;

Thread main = Thread.CurrentThread;
main.Name = "Main Thread";
Console.WriteLine($"ID: {main.ManagedThreadId}");
Console.WriteLine($"Name: {main.Name}");
Console.WriteLine($"IsAlive: {main.IsAlive}");
Console.WriteLine($"Priority: {main.Priority}");
Console.WriteLine($"State: {main.ThreadState}");
Console.WriteLine();
Console.ReadKey();
