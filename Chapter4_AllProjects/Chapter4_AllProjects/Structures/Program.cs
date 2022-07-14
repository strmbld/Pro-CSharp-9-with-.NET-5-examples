using System;
using System.Collections;

namespace Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** struct *****");

            Point mPoint = new Point();
            mPoint.Display();
            mPoint.X = 349;
            mPoint.Y = 76;
            mPoint.Display();
            mPoint.Increment();
            mPoint.Display();
            mPoint.Increment(10);
            mPoint.Display();
            mPoint.Decrement();
            mPoint.Display();
            mPoint.Decrement(9);
            mPoint.Display();
            Console.WriteLine();

            PointWithPartialReadOnly mPWPR = new PointWithPartialReadOnly(5, 3);
            mPWPR.Display();
            PointWithPartialReadOnly mPWPR2 = new PointWithPartialReadOnly(name: "new readonly");
            mPWPR2.Display();
            Console.WriteLine();

            DisposableRefStruct drs = new DisposableRefStruct(1, 2, "drs");
            drs.Display();
            drs.Dispose();
            Console.WriteLine();
        }
    }

    struct Point : IEnumerable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }
        public void Increment(int incr = 1)
        {
            X = X + incr;
            Y = Y + incr;
        }

        public void Decrement(int decr = 1)
        {
            X = X - decr;
            Y = Y - decr;
        }

        public void Display()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    readonly struct ReadOnlyPoint
    {
        public int X { get; }
        public int Y { get; }

        public ReadOnlyPoint(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public void Display()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
        }
    }

    struct PointWithPartialReadOnly
    {
        public int X { get; set; }
        public int Y { get; set; }

        public readonly string Name { get; }

        public PointWithPartialReadOnly(int x = 0, int y = 0, string name = default)
        {
            X = x;
            Y = y;
            Name = name;
        }

        public void Display()
        {
            Console.WriteLine($"X = {X}, Y = {Y}, Name = {Name}");
        }
    }

    ref struct DisposableRefStruct
    {
        public int X { get; set; }
        public int Y { get; set; }
        public readonly string Name { get; }

        public DisposableRefStruct(int x = 0, int y = 0, string name = default)
        {
            X = x;
            Y = y;
            Name = name;
            Console.WriteLine("Created DisposableRefStruct instance");
        }

        public void Display()
        {
            Console.WriteLine($"X = {X}, Y = {Y}, Name = {Name}");
        }

        public void Dispose()
        {
            // clean up
            Console.WriteLine("Disposed");
        }
    }
}
