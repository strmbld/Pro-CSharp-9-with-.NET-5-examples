using System;
using System.Threading;
using AddWithThreads;

AutoResetEvent waitHandle = new(false);

Console.WriteLine($"Main thread ID: {Thread.CurrentThread.ManagedThreadId}");

AddParams ap = new(10, 10);
Thread t = new(new ParameterizedThreadStart(Add));
t.Start(ap);

// Thread.Sleep(5); // wait for another thread

waitHandle.WaitOne(); // proper way
Console.WriteLine("another thread is done");
Console.ReadKey();

void Add(object data)
{
    if (data is AddParams ap)
    {
        Console.WriteLine($"Add() thread ID: {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine($"{ap.a} + {ap.b} = {ap.a + ap.b}");

        // signal to main thread
        waitHandle.Set();
    }
}