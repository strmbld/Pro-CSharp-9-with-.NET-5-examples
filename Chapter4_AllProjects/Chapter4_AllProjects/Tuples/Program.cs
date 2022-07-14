using System;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Tuples *****");

            (string, int, string) vals = ("b", 7, "d");
            var values = ("a", 5, "c");
            Console.WriteLine(values.GetType().FullName);
            Console.WriteLine();
            (string FirstS, int Number, string SecondS) valuesWNames = ("f", 3, "r");
            var valuesWNames2 = (FirstS: "t", Number: 5, SecondS: "y");
            Console.WriteLine(valuesWNames.Item1);

            var foo = new { Pro1 = "first1", Pr = "second" };
            var bar = (foo.Pro1, foo.Pr);
            Console.WriteLine(bar);

            //(string a, _, string c) valls = SplitName("Josh D Peterson");
            var (first, _, last) = SplitName("Josh D Peterson");
            Console.WriteLine(first + " " + last);
            Console.WriteLine();

            Point p = new Point(7, 5);
            Console.WriteLine($"x: {p.X}, y: {p.Y}");
            var coords = p.Deconstruct();
            Console.WriteLine($"x: {coords.x}, y: {coords.y}");
            Console.WriteLine();
        }

        static string GetQuadrant2(Point p)
        {
            return p switch
            {
                (0, 0) => "Origin",
                var (x, y) when x > 0 && y > 0 => "One",
                var (x, y) when x < 0 && y > 0 => "Two",
                var (x, y) when x < 0 && y < 0 => "Three",
                var (x, y) when x > 0 && y < 0 => "Four",
                var (_, _) => "Border",
            };
        }
        static string GetQuadrant1(Point p)
        {
            return p.Deconstruct() switch
            {
                (0, 0) => "Origin",
                var (x, y) when x > 0 && y > 0 => "One",
                var (x, y) when x < 0 && y > 0 => "Two",
                var (x, y) when x < 0 && y < 0 => "Three",
                var (x, y) when x > 0 && y < 0 => "Four",
                var (_, _) => "Border",
            };
        }

        static void FillValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "some string";
            c = true;
        }

        static (int a, string b, bool c) FillValues()
        {
            return (9, "some string", true);
        }

        static (string first, string middle, string last) SplitName(string fullName)
        {
            string[] tokens = fullName.Split(' ');
            return (tokens[0], tokens[1], tokens[2]);
        }

        static string PaperScissorsRock(string first, string second)
        {
            return (first, second) switch
            {
                ("rock", "paper") => "Paper wins.",
                ("rock", "scissors") => "Rock wins.",
                ("paper", "rock") => "Paper wins.",
                ("paper", "scissors") => "Scissors wins.",
                ("scissors", "rock") => "Rock wins.",
                ("scissors", "paper") => "Scissors wins.",
                (_, _) => "Tie.",
            };
        }

        static string RockPaperScissors((string first, string second) value)
        {
            return value switch
            {
                ("rock", "paper") => "Paper wins.",
                ("rock", "scissors") => "Rock wins.",
                ("paper", "rock") => "Paper wins.",
                ("paper", "scissors") => "Scissors wins.",
                ("scissors", "rock") => "Rock wins.",
                ("scissors", "paper") => "Scissors wins.",
                (_, _) => "Tie.",
            };
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public (int x, int y) Deconstruct() => (X, Y);

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        }
    }
}
