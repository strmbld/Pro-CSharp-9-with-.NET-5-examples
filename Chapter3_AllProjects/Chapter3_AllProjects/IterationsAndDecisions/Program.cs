using System;
using System.Text;

namespace IterationsAndDecisions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Iterations *****");

            ForLoop();
            ForEachLoop();
            WhileLoop();
            DoWhileLoop();
            IfElseExample();
            IfElsePatternMatching();
            IfElsePatternMatchingCS9();
            ConditionalRefExample();
            SwitchExample();
            SwitchEnumExample();
            PatternMatchingSwitch();
            Console.WriteLine(PaperScissorsRock("paper", "rock"));
            Console.WriteLine(PaperScissorsRock("scissors", "rock"));
        }

        static void ForLoop()
        {
            for (int i = 0; i < 4; i++) Console.WriteLine($"i: {i}");
            Console.WriteLine();
        }

        static void ForEachLoop()
        {
            string[] cars = { "Ford", "BMW", "Honda" };
            foreach (var s in cars) Console.WriteLine(s);

            int[] ints = { 10, 20, 30, 40 };
            foreach (int i in ints) Console.WriteLine(i);
        }

        static void WhileLoop()
        {
            string input = "";
            while (input.ToLower() != "yes")
            {
                Console.WriteLine("In loop");
                Console.WriteLine("break? yes no: ");
                input = Console.ReadLine();
            }
        }

        static void DoWhileLoop()
        {
            string input = "";
            do
            {
                Console.WriteLine("In do/while loop");
                Console.WriteLine("break? yes no: ");
                input = Console.ReadLine();
            } while (input.ToLower() != "yes");
        }

        static void IfElseExample()
        {
            // This is illegal, given that Length returns an int, not a bool.
            string stringData = "My textual data";
            if (stringData.Length > 0) // if (stringData.Length) {} won't work
            {
                Console.WriteLine("string is greater than 0 characters");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("string is not greater than 0 characters");
            Console.WriteLine();
        }

        static void IfElsePatternMatching()
        {
            Console.WriteLine("*** Pattern matching ***");

            object test1 = 123;
            object test2 = "hello";

            if (test1 is int)
            {
                Console.WriteLine("TRUE");
            }

            if (test1 is string mString1)
            {
                Console.WriteLine($"{mString1} is a string");
            }

            if (test1 is int mValue1)
            {
                Console.WriteLine($"{test1} is an integer"); // why mValue1 when you test test1 var; theremore if not assigned falls to default/null
            }

            if (test2 is string mString2) Console.WriteLine($"{mString2} is a string");
            if (test2 is int mValue2) Console.WriteLine($"{mValue2} is an int");

        }

        static void IfElsePatternMatchingCS9()
        {
            Console.WriteLine("C#9 if else pattern matching*********");

            object test1 = 123;
            Type t = typeof(string);
            char c = 'f';

            if (t is Type)
            {
                Console.WriteLine($"{t} is a Type");
            }

            if (c is >= 'a' and <= 'z' or >= 'A' and <= 'Z')
            {
                Console.WriteLine($"{c} is a char");
            }

            if (c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',')
            {
                Console.WriteLine($"{c} is a char or separator");
            }

            if (test1 is not string)
            {
                Console.WriteLine($"{test1} is not a string");
            }

            if (test1 is not null)
            {
                Console.WriteLine($"{test1} is not null");
            }

            Console.WriteLine($"test1 is {test1.GetType().FullName}");

            Console.WriteLine();
        }

        static void ConditionalRefExample()
        {
            var smallArray = new int[] { 1, 2, 3, 4, 5 };
            var largeArray = new int[] { 10, 20, 30, 40, 50 };
            int index = 7;
            ref int refVal = ref(index < 5 ? ref smallArray[index] : ref largeArray[index - 5]);
            ref int refValue = ref ((index < 5)
            ? ref smallArray[index]
            : ref largeArray[index - 5]);
            refValue = 0;
            index = 2;
            ((index < 5)
            ? ref smallArray[index]
            : ref largeArray[index - 5]) = 100;
            Console.WriteLine(string.Join(" ", smallArray));
            Console.WriteLine(string.Join(" ", largeArray));
        }

        static void SwitchExample()
        {
            Console.WriteLine("1 C#, 2 php, 3 c++");
            Console.WriteLine("Pick language:");

            string choice = Console.ReadLine();
            // int n = int.Parse(choice);
            switch (choice) // switch (n)
            {
                case "1":
                    Console.WriteLine("fine");
                    break;
                case "2":
                    Console.WriteLine("good");
                    break;
                case "3":
                    Console.WriteLine("what a nerd");
                    break;
                default:
                    Console.WriteLine("you lost");
                    break;
            }
        }

        static void SwitchEnumExample()
        {
            Console.WriteLine("Pick favorite day of week:");

            DayOfWeek day;
            try
            {
                string s = Console.ReadLine();
                day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), s[0].ToString().ToUpper() + s.Substring(1));
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input");
                return;
            }
            switch (day)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine("work again");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("not monday but still");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("50/50");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("bit more");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("yeah friday");
                    break;
                case DayOfWeek.Saturday:
                    // goto case DayOfWeek.Sunday;
                case DayOfWeek.Sunday:
                    Console.WriteLine("here we go again");
                    break;
            }
            Console.WriteLine();
        }

        static void PatternMatchingSwitch()
        {
            Console.WriteLine("1 => int 5, 2 => string 'Hi', 3 => decimal 2.5");
            Console.WriteLine("Pick an option:");
            string sChoice = Console.ReadLine();
            object oChoice;
            switch (sChoice)
            {
                case "1":
                    oChoice = 5;
                    break;
                case "2":
                    oChoice = "Hi";
                    break;
                case "3":
                    oChoice = 2.5m;
                    break;
                default:
                    oChoice = 5;
                    break;
            }
            switch (oChoice)
            {
                case int i:
                    Console.WriteLine("Choice: integer");
                    break;
                case string s:
                    Console.WriteLine($"Choice: string => {s}"); // works like 'is' => assigns value to 'output var'
                    break;
                case decimal: // same as for 'is' we may omit var for assignment
                    Console.WriteLine("Choice: decimal");
                    break;
                default:
                    Console.WriteLine("wrong choice");
                    break;
            }
            Console.WriteLine();
        }

        static string Colors(string color)
        {
            return color switch
            {
                "Red" => "#FF0000",
                "Orange" => "#FF7F00",
                "Yellow" => "#FFFF00",
                "Green" => "#00FF00",
                _ => "#FFFFFF",
            };
        }

        static string PaperScissorsRock(string first, string second)
        {
            return (first, second) switch
            {
                ("rock", "paper") => "Paper/second wins",
                ("rock", "scissors") => "Rock/first wins",
                ("paper", "rock") => "Paper/first wins",
                ("paper", "scissors") => "Scissors/second wins",
                ("scissors", "rock") => "Rock/second wins",
                ("scissors", "paper") => "Scissors/first wins",
                (_, _) => "Tie",
            };
        }
    }
}
