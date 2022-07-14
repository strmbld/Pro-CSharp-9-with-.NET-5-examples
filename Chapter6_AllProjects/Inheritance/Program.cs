using System;
using Inheritance;

Console.WriteLine("***** Inhertitance *****");

Car car = new(80) { Speed = 50 };
Console.WriteLine($"{car.Speed}");
Console.WriteLine();

MiniVan van = new MiniVan { Speed = 10 };
Console.WriteLine($"{van.Speed}");
Console.WriteLine();