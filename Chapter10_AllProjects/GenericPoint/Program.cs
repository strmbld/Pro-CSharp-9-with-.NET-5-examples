using System;
using GenericPoint;

Point<int> pInt = new(10, 10);
Console.WriteLine(pInt);
pInt.Reset();
Console.WriteLine(pInt);
Console.WriteLine();

Point<double> pDouble = new(5.4, 3.3);
Console.WriteLine(pDouble);
pDouble.Reset();
Console.WriteLine(pDouble);
Console.WriteLine();

Point<string> pString = new("i", "3i");
Console.WriteLine(pString);
pString.Reset();
Console.WriteLine(pString);
Console.WriteLine();

static void PatternMatching<T>(Point<T> p)
{
    switch (p)
    {
        case Point<string> pString:
            Console.WriteLine("Point is based on strings");
            return;
        case Point<int> pInt:
            Console.WriteLine("Point is based on ints");
            return;
    }
}