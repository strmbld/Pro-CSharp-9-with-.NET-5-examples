using System;

namespace TypeConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Type Conversions *****");

            short n1 = 9;
            short n2 = 10;
            // short res1 = Add(n1, n2);
            Console.WriteLine($"sum: {Add(n1, n2)}");
            short n3 = 30000; // max short 32767
            short n4 = 20000;
            // short res2 = Add(n3, n4);
            // short res2 = Convert.ToInt16(Add(n3, n4));
            short res2 = (short)Add(n3, n4); // -32768 + (50000 - 32767) = 15535
            Console.WriteLine($"sum: {Add(n3, n4)}");
            Console.WriteLine($"conver to int16: {res2}");

            ProcessBytes();
        }

        static void ProcessBytes()
        {
            byte b1 = 100; // byte is unsigned [0; 255]; there is sbyte type for -128:127 range
            byte b2 = 250;

            try
            { 
                byte sum = checked((byte)Add(b1, b2)); // could use 'checked scope' like try{ checked{...}} catch(){}}
                Console.WriteLine($"sum: {sum}"); // unchecked could be usefull with global checked set in project settings
            } 
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static int Add(int x, int y)
        {
            return x + y;
        }
    }
}
