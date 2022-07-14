using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericMethods
{
    static class SwapFunctions
    {
        public static void Swap<T>(ref T a, ref T b) // where T : struct
        {
            Console.WriteLine($"Call Swap<{typeof(T)}>");
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
