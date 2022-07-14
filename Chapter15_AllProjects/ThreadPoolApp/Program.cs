using System;
using System.Threading;
using ThreadPoolApp;

Console.WriteLine($"Main thread ID: {Thread.CurrentThread.ManagedThreadId}");

Printer p = new();

WaitCallback workItem = new(PrintTheNumbers);

for (int i = 0; i < 10; i++)
{
    ThreadPool.QueueUserWorkItem(workItem, p);
}
Console.WriteLine("All tasks queued");
Console.ReadKey();

static void PrintTheNumbers(object state)
{
    Printer task = (Printer)state;
    task.PrintNumbers();
}