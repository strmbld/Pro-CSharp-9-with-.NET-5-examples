using System;
using System.Diagnostics.CodeAnalysis;

namespace LocalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Local functions *****");

            
        }

#nullable enable
        private static void Process(string?[] lines, string mark)
        {
            foreach (var line in lines)
            {
                if (IsValid(line))
                {
                    // Processing logic...
                }
            }
            bool IsValid([NotNullWhen(true)] string? line)
            {
                return !string.IsNullOrEmpty(line) && line.Length >= mark.Length;
            }
        }
        static int Add(int x, int y)
        {
            return x + y;
        }

        static int AddWrapper(int x, int y)
        {
            return Add();

            int Add()
            {
                // non-static local function has direct access to local vars, don't need params and can do something like
                // x += 1 what is probably not needed
                return x + y;
            }
        }

        static int AddWrapperWithStaticLocal(int x, int y)
        {
            return Add(x, y); // local scope for super function

            static int Add(int x, int y)
            {
                // local scope for nested func

                x += 1; // <= this x is not the same as local x from above so change will affect only local x for static func
                return x + y;
            }
        }
    }
}
