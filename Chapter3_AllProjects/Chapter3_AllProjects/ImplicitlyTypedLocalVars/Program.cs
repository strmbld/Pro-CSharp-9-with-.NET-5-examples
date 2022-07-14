using System;
using System.Linq;

namespace ImplicitlyTypedLocalVars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Implicit Typing *****");

            DeclareImplicitVars();
            DeclareImplicitNumerics();
            LinqQueryOverInts();
        }

        static void DeclareImplicitVars()
        {
            var mInt = 0;
            var mBool = true;
            var mString = "something";

            Console.WriteLine($"mInt type: {mInt.GetType().FullName}");
            Console.WriteLine($"mBool type: {mBool.GetType().FullName}");
            Console.WriteLine($"mString type: {mString.GetType().FullName}");
        }

        static void DeclareImplicitNumerics()
        {
            // Implicitly typed numeric variables.
            var myUInt = 0u;
            var myInt = 0;
            var myLong = 0L;
            var myDouble = 0.5;
            var myFloat = 0.5F;
            var myDecimal = 0.5M;
            // Print out the underlying type.
            Console.WriteLine("myUInt is a: {0}", myUInt.GetType().Name);
            Console.WriteLine("myInt is a: {0}", myInt.GetType().Name);
            Console.WriteLine("myLong is a: {0}", myLong.GetType().Name);
            Console.WriteLine("myDouble is a: {0}", myDouble.GetType().Name);
            Console.WriteLine("myFloat is a: {0}", myFloat.GetType().Name);
            Console.WriteLine("myDecimal is a: {0}", myDecimal.GetType().Name);
        }

        static void LinqQueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            var subset = from i in numbers where i < 10 select i;
            Console.WriteLine("subset values:");
            foreach (var i in subset) Console.WriteLine($"{i}");
            Console.WriteLine();
            Console.WriteLine($"subset is: {subset.GetType().FullName}");
            Console.WriteLine($"defined in: {subset.GetType().Namespace}");
        }
    }
}
