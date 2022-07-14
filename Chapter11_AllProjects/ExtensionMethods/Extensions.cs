using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ExtensionMethods
{
    static class Extensions
    {
        public static void DisplayDefiningAssembly(this object obj) // extending System.Object
            => Console.WriteLine($"{obj.GetType().Name} lives here: {Assembly.GetAssembly(obj.GetType()).GetName().Name}");
        public static int ReverseDigits(this int i) // may have more params but first always should point on extended type 'this T x, ...'
        {
            char[] digits = i.ToString().ToCharArray();
            Array.Reverse(digits);
            return int.Parse(new string(digits));
        }
    }
}
