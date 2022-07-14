using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExtensions
{
    static class Extensions
    {
        public static void PrintData(this System.Collections.IEnumerable iterator)
        {
            foreach (var item in iterator)
            {
                Console.WriteLine(item);
            }
        }
    }
}
