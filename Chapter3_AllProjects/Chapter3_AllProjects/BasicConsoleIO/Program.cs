using System;

namespace BasicConsoleIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Basic Console I/O *****");
            GetUserData();
            Console.WriteLine("Currency: {0:x}", 228);
            string arg = Console.ReadLine();
            FormatNumericData(Convert.ToInt32(arg));
            Console.ReadKey();
            static void GetUserData()
            {
                Console.WriteLine("Your name: ");
                string userName = Console.ReadLine();
                Console.WriteLine("Age: ");
                string userAge = Console.ReadLine();

                ConsoleColor prevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("hello {0} there you're {1} years old", userName, Convert.ToInt32(userAge) + 100);

                Console.ForegroundColor = prevColor;
            }

            static void FormatNumericData(int value)
            {
                Console.WriteLine("The value {0} in various formats: ", value);
                Console.WriteLine("c format: {0:c}", value);
                Console.WriteLine("d9 format: {0:d9}", value);
                Console.WriteLine("f3 format: {0:f3}", value);
                Console.WriteLine("n format: {0:n}", value);
                Console.WriteLine("E format: {0:E}", value);
                Console.WriteLine("e format: {0:e}", value);
                Console.WriteLine("X format: {0:X}", value);
                Console.WriteLine("x format: {0:x}", value);
            }
        }
    }
}
