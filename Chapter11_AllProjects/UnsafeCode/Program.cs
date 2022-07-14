using System;

namespace UnsafeCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StackAlloc());
        }

        static unsafe string StackAlloc()
        {
            char* p = stackalloc char[100];
            for (int i = 0; i < 100; i++)
            {
                p[i] = (char)(i + 65);
            }
            return new string(p);
        }
        
    }
}
