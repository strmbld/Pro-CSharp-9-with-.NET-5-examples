using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMultiThreadApp
{
    class Printer
    {
        public void PrintNumbers()
        {
            Console.WriteLine($"-> {Thread.CurrentThread.Name} is executing Printer.PrintNumbers()");
            Console.WriteLine($"Numbers:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i}, ");
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
}
