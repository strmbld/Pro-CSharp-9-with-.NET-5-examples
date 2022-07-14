using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Methods *****");

            FillValuesMutator(out int a, out string b, out bool c);
            Console.WriteLine($"int a=={a}; string b=={b}; bool c=={c}");
            a = a * 3;
            Console.WriteLine(a);
            Console.WriteLine();
            string tst = "abc";
            Console.WriteLine(tst);
            Test(ref tst);
            Console.WriteLine(tst);
            double avg = CalcAvg(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine($"Avg: {avg}");
            Console.WriteLine();
            EnterLogData("error1", "owner of error1");
            EnterLogData("error2");
            DisplayMessage(ConsoleColor.DarkGreen, ConsoleColor.Gray, "hello there");
            DisplayMessage(
                message: "named parameters usage",
                textColor: ConsoleColor.DarkRed,
                backgroundColor: ConsoleColor.DarkGray
            );

        }

        static void DisplayMessage(ConsoleColor textColor, ConsoleColor backgroundColor, string message)
        {
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);
            // restore
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldBackgroundColor;
        }

        static void EnterLogData(string message, string owner = "Programmer") // default value fallbacks should be known at compile-time
            // optional parameters should follow after required
        {
            Console.WriteLine($"Error: {message}");
            Console.WriteLine($"Owner: {owner}");
        }
        static double CalcAvg(params double[] values) // can only have 1 params and it should be final/last one in param list
        {
            Console.WriteLine($"CalcAvg input length: {values.Length}");

            double sum = 0;
            if (values.Length == 0)
            {
                return sum;
            }
            foreach (var value in values)
            {
                sum += value;
            }
            return sum / values.Length;
        }

        static int AddReadOnly(in int x, in int y) // aka const& or 'const ref'
        {
            // x = 10000;
            // y = 21931283;
            int res = x + y;
            return res;
        }
        static void Test(ref string tst)
        {
            tst += "123";
        }

        static void FillValuesMutator(out int a, out string b, out bool c) // out is contract to initialize
        {
            a = 9;
            b = "string";
            c = true;
        }
        static void AddWithOutputParam(int x, int y, out int res)
        {
            res = x + y;
        }
        static int Add(int x, int y)
        {
            int res = x + y;
            x = 10000; // caller won't see changes since these are local copies, param vars are passed by value
            y = 88888; // same for string type though it's reference type/object but aswell passed by value/copy
            return res;
        }
    }
}
