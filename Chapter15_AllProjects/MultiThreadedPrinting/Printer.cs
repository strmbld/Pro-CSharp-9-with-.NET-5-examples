using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadedPrinting
{
    class Printer
    {
        private object threadLock = new();
        public void PrintNumbers()
        {
            lock (threadLock)
            {
                Console.WriteLine($"-> {Thread.CurrentThread.Name} is executing Printer.PrintNumbers()");
                Console.WriteLine($"Numbers:");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000 * new Random().Next(5));
                    Console.Write($"{i}, ");
                }
                Console.WriteLine();
            }
        }
    }
}
