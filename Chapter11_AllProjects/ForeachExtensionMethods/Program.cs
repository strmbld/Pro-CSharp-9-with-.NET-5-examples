using System;

namespace ForeachExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage g = new();
            foreach (Car car in g)
            {
                Console.WriteLine($"{car.Name} speed: {car.Speed}");
            }
        }
    }
}
