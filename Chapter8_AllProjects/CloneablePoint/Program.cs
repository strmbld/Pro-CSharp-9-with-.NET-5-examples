using System;

namespace CloneablePoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Point p1 = new(100, 100);
            Point p2 = p1;
            p2.X = 50;
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());
            Console.WriteLine();

            Point p3 = new(100, 100);
            Point p4 = (Point)p3.Clone();
            p4.X = 0;
            Console.WriteLine(p3);
            Console.WriteLine(p4);
        }
    }
}
