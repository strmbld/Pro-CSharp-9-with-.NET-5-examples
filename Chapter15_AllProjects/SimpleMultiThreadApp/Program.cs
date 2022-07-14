using System;
using System.Threading;
using SimpleMultiThreadApp;

Console.WriteLine("[1] or [2] threads?");
string numOfThreads = Console.ReadLine();

Thread main = Thread.CurrentThread;
main.Name = "Main";

Console.WriteLine($"-> {Thread.CurrentThread.Name} is executing Main()");

Printer p = new Printer();

switch (numOfThreads)
{
    case "2":
        Thread background = new Thread(new ThreadStart(p.PrintNumbers));
        background.Name = "Secondary";
        // background.IsBackground = true; // now truly 'background'; main+all workers are foreground by default 
        background.Start();
        break;
    case "1":
        p.PrintNumbers();
        break;
    default:
        Console.WriteLine("wrong input; running 1 thread");
        goto case "1";
}
Console.WriteLine();
Console.WriteLine("finished work on Main");
Console.ReadKey();