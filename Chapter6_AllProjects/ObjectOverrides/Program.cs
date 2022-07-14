using System;
using ObjectOverrides;

Console.WriteLine("***** Object Overrides *****");

Person p1 = new("p1", 33, "88005553535");
Console.WriteLine($"ToString: {p1.ToString()}");
Console.WriteLine($"GetHashCode: {p1.GetHashCode()}");
Console.WriteLine($"Type: {p1.GetType()}");
Console.WriteLine();
Person p2 = p1;
object o = p2;
if (o.Equals(p1) && p2.Equals(o))
{
    Console.WriteLine("Same instance");
}
Console.WriteLine();
p1.Name = "test";
Console.WriteLine($"GetHashCode: {p1.GetHashCode()}");
Console.WriteLine($"{p1.ToString()}");