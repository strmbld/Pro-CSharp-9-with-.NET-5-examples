using System;
using CustomGenericMethods;

int a = 10;
int b = 90;
Console.WriteLine($"{a}, {b}");
SwapFunctions.Swap<int>(ref a, ref b);
Console.WriteLine($"{a}, {b}");
Console.WriteLine();

string s1 = "hello";
string s2 = "there";
Console.WriteLine($"{s1}, {s2}");
SwapFunctions.Swap<string>(ref s1, ref s2);
Console.WriteLine($"{s1}, {s2}");
Console.WriteLine();