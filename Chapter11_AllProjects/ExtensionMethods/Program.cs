using System;
using ExtensionMethods;

int i = 12345678;
i.DisplayDefiningAssembly();
Console.WriteLine();
System.Data.DataSet d = new();
d.DisplayDefiningAssembly();
Console.WriteLine();
Console.WriteLine(i);
Console.WriteLine(i.ReverseDigits());
Console.WriteLine();
