using System;

namespace NullableDataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** nullable data types *****");
#nullable enable
            string? nString = null;
            Person? nPerson = null;
#nullable disable
            LocalNullableValueTypeVars();
            NCAssignmentOperator();
        }

        static void NCAssignmentOperator()
        {
            int? nInt = null;
            nInt ??= 12; // equals to notation: nInt = nInt ?? 12;
            nInt ??= 14;
            Console.WriteLine(nInt);
            Console.WriteLine();
        }

        static void LocalNullableValueTypeVars()
        {
            int? nullableInt = 10;
            int? nullableInt2 = null;
            double? nDouble = 3.14;
            bool? nBool = null;
            char? nChar = 'a';
            string s = null;
            int?[] arrOfnInts = new int?[10];
            Nullable<int> nInt = 11;
            Nullable<double> nDouble2 = 3.1415926;
            Nullable<int>[] nInts = new Nullable<int>[10];

            int nInt3 = nullableInt2 ?? 100;
            Console.WriteLine(nInt3);
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Test
    {
        public string S { get; set; }
    }
}
