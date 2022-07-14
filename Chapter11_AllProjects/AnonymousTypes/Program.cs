using System;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildAnonymousType("BMW", "red", 50);
            var c = new { Name = "w/e", Age = 55 };
            Console.WriteLine(c.ToString());
            // c.Age = 105; readonly, init setter
            Console.WriteLine();
            ReflectOverAnonymousType(c);
            Console.WriteLine();

            var c1 = new { Name = "w/e", Age = 55 };
            var c2 = new { Name = 1, Age = 55 };
            ReflectOverAnonymousType(c1);
            ReflectOverAnonymousType(c2);
            Console.WriteLine(c1.Equals(c2));
            Console.WriteLine();
            var test = (1, "a", 3);
            ReflectOverAnonymousType(test);
            Console.WriteLine();

            Console.WriteLine(c1.GetType().Name);
            Console.WriteLine(c2.GetType().Name); // generated definition is the same due to equal properties names thought different values or types
            // Equals() has value-based behavior; ==/!= operators are not overloaded so they compare references which are different for 2+ different objects even with same values
            // hashcode is value based and is same for different object but same values
            Console.WriteLine();

            var purchase = new
            {
                Time = DateTime.Now,
                Item = new {Color = "Red", Make = "Saab", Speed = "55"},
                Price = 34.000,
            };
            ReflectOverAnonymousType(purchase);
            Console.WriteLine();
        }
        static void BuildAnonymousType(string make, string color, int speed)
        {
            var car = new { Make = make, Color = color, Speed = speed };
            Console.WriteLine(car.ToString());
            Console.WriteLine($"stats: {car.Make}, {car.Color}, {car.Speed}");
        }
        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of: {0}",
            obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}",
            obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("obj.ToString() == {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode() == {0}",
            obj.GetHashCode());
            Console.WriteLine();
        }
    }
}
