using System;

namespace SimpleDispose
{
    class Program
    {
        static void Main(string[] args)
        {
            ResourceWrapper rw = new();
            if (rw is IDisposable)
            {
                try
                {
                    // using members of rw
                }
                finally
                {
                    rw.Dispose();
                }
            }

            // better syntax, same CIL
            using (ResourceWrapper rw2 = new())
            {
                // messing with resources
            }
            // Dispose() called after leaving using scope automatically
            using (ResourceWrapper rw3 = new(), rw4 = new(), rw5 = new())
            {
                // 
            }
            Console.WriteLine("*************");
            UsingDeclaration();
            
        }

        private static void UsingDeclaration()
        {
            using var rw = new ResourceWrapper();
            // code
            Console.WriteLine("About to dispose");
            // out of scope & Dispose() called automatically
        }
    }
}
