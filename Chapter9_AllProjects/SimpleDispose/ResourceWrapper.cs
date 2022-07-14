using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDispose
{
    class ResourceWrapper : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Call ResourceWrapper.Dispose()");
        }

        ~ResourceWrapper() => Console.WriteLine("Destroyed");
    }
}
