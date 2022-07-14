using System;
using System.Threading;
using MultiThreadedPrinting;

Printer p = new();

Thread[] threads = new Thread[10];
for (int i = 0; i < 10; i++)
{
    threads[i] = new(new ThreadStart(p.PrintNumbers))
    {
        Name = $"Worker thread #{i}"
    };
}
foreach (Thread thread in threads)
{
    thread.Start();
}
Console.ReadKey();

static void CompareAndExchange()
{
    int i = 83;
    // If the value of i is currently 83, change i to 99.
    Interlocked.CompareExchange(ref i, 99, 83);
}