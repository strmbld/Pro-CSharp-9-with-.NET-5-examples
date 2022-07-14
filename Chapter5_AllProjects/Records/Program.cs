using System;

namespace Records
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Records *****");

            Car car1 = new("Honda", "Pilot", "Blue");
            Console.WriteLine("car1:");
            Show(car1);
            Console.WriteLine();

            Car car2 = new("Lambo", "Gallardo", "Black");
            Console.WriteLine("car2:");
            Show(car2);
            Console.WriteLine();

            CarRecord car3 = new("taz", "2109", "cherry ofc");
            Console.WriteLine(car3.ToString());
            Console.WriteLine();
        }

        static void Show(Car c)
        {
            Console.WriteLine($"Car Make: {c.Make}");
            Console.WriteLine($"Car Model: {c.Model}");
            Console.WriteLine($"Car Color: {c.Color}");
        }
    }
}
