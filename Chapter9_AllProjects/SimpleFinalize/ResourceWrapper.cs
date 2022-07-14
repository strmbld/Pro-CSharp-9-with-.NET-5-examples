using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFinalize
{
    class ResourceWrapper
    {
        ~ResourceWrapper() => Console.WriteLine("Destroyed");
    }
}
