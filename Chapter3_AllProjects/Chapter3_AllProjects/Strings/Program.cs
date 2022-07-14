using System;
using System.Text;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicStringFunctionality();
            StringInterpolation();
            VerbatimStrings();
            StringEquality();
            StringEqualityWithCompareRules();
            TryStringBuilder();
        }

        static void TryStringBuilder()
        {
            Console.WriteLine("*****StringBuilder usage*****");
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****", 128);
            sb.Append('\n');
            sb.AppendLine("Half Life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + '2');
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            sb.Replace("2", " Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine($"sb length: {sb.Length}");
            Console.WriteLine();
        }

        static void StringEqualityWithCompareRules()
        {
            Console.WriteLine("*****String equality:*****");
            string s1 = "Hello!";
            string s2 = "HELLO!";
            Console.WriteLine($"s1 = {s1}");
            Console.WriteLine($"s2 = {s2}");
            Console.WriteLine();

            Console.WriteLine($"Default rules: s1 = {s1}, s2 = {s2}: {s1.Equals(s2)}");
            Console.WriteLine($"Ignore case s1.Equals(s2, StringComparison.OrdinalIgnoreCase): {s1.Equals(s2, StringComparison.OrdinalIgnoreCase)}");
            Console.WriteLine($"Ignore case .InvariantCultureIgnoreCase: {s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase)}");
            Console.WriteLine();
            Console.WriteLine("IndexOf");
            Console.WriteLine($"Default rules s1.IndexOf(\"E\"): {s1.IndexOf("E")}");
            Console.WriteLine($"Ignore case StringComparison.OrdinalIgnoreCase: {s1.IndexOf("E", StringComparison.OrdinalIgnoreCase)}");
            Console.WriteLine($"InvarianCultureIgnoreCase: {s1.IndexOf("E", StringComparison.InvariantCultureIgnoreCase)}");
            Console.WriteLine();
        }
        static void StringEquality()
        {
            Console.WriteLine("*****String Equality*****");
            string s1 = "Hello!";
            string s2 = "Yo!";
            Console.WriteLine($"s1 = {s1}");
            Console.WriteLine($"s2 = {s2}");
            Console.WriteLine();
            Console.WriteLine($"s1 == s2: {s1 == s2}");
            Console.WriteLine($"s1 == Hello!: {s1 == "Hello!"}");
            Console.WriteLine($"s1 == HELLO!: {s1 == "HELLO!"}");
            Console.WriteLine($"s1 == hello!: {s1 == "hello!"}");
            Console.WriteLine($"s1.Equals(s): {s1.Equals(s2)}");
            Console.WriteLine($"Yo!.Equals(s2): {"Yo!".Equals(s2)}");
            Console.WriteLine();
        }

        static void VerbatimStrings()
        {
            Console.WriteLine("*****Verbatim Strings*****");
            Console.WriteLine(@"C:\App\bin\Debug");
            string ls = @"This is a very
very
                very
                                 very
                long                             string";
            Console.WriteLine(ls);
            Console.WriteLine("Dog said \"gaf gaf\"");
            Console.WriteLine(@"Dog said ""gaf gaf""");
        }
        static void StringInterpolation()
        {
            Console.WriteLine("String Interpolation");

            int age = 4;
            string name = "Name";

            string greeting = string.Format("hello there {0} you're {1} years old", name, age);
            Console.WriteLine(greeting);

            string greeting2 = $"\tHello {name.ToUpper()} you're {age.GetHashCode()} years old";
            int hs = age.GetHashCode();
            Console.WriteLine(greeting2);
            Console.WriteLine(hs);
        }
        static void BasicStringFunctionality()
        {
            Console.WriteLine("*****Basic String Functionality*****");

            string name = "Freddy";

            Console.WriteLine("Value: {0}", name);
            Console.WriteLine("Length: {0}", name.Length);
            Console.WriteLine("UC: {0}", name.ToUpper());
            Console.WriteLine("Value: {0}", name);
            name += "123"; // to check if string is really immutable in C#
            Console.WriteLine("Value: {0}", name); // looks like += operator is overrided and creates new string in heap
            // yeah indeed + and += operators just call String.Concat(s1,s2) method returning new string
            Console.WriteLine("LC: {0}", name.ToLower());
            Console.WriteLine("Contains 'y': {0}", name.Contains('y'));
            Console.WriteLine("Replace 'dy' with empty: {0}", name.Replace("dy", ""));
            Console.WriteLine();
        }
    }
}
