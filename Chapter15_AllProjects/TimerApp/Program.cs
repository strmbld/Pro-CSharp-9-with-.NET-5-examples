using System;
using System.Threading;

TimerCallback timeCB = new(PrintTime);

Timer t = new(
    timeCB,
    null, // data to pass into callback method; 'object state' arg in PrintTime currently
    0, // initial delay in ms
    1000 // time between calls in ms
);

Console.WriteLine("any key to terminate");
Console.ReadKey();

static void PrintTime(object state)
{
    Console.WriteLine($"Time: {DateTime.Now.ToLongTimeString()}");
}