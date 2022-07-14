using System;

namespace ObjectInitialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Obj Init *****");

            Point point1 = new Point();
            point1.X = 10;
            point1.Y = 10;
            point1.Show();
            Console.WriteLine();

            Point point2 = new Point(20, 20);
            point2.Show();
            Console.WriteLine();

            Point point3 = new Point { X = 30, Y = 30 }; // need default (){} ctor to use this syntax
            point3.Show();
            Console.WriteLine();

            PointInitOnlySetters iosPoint1 = new(20, 20);
            iosPoint1.Show();
            Console.WriteLine();

            PointInitOnlySetters iosPoint2 = new(40, 40);
            iosPoint2.Show();
            Console.WriteLine();
        }
    }
}
