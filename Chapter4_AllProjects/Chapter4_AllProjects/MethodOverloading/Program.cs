using System;
using static MethodOverloading.AddOperations;

namespace MethodOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Method Overloading *****");

            Console.WriteLine(Add(10, 10));
            Console.WriteLine(Add(900_000_000_000, 900_000_000_000));
            Console.WriteLine(Add(4.3, 4.4));
            Console.WriteLine();
        }
    }

    public static class AddOperations
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static long Add(long x, long y)
        {
            return x + y;
        }

        public static int Add(in int x, in int y) // have to choose between out, ref, in cuz they're not part of sig
        {
            return x + y;
        }

        /*
        public static int Add(out int x, out int y)
        {
            return x + y;
        }*/
    }
}
