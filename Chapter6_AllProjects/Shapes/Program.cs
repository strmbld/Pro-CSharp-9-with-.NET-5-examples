using System;
using Shapes;

Console.WriteLine("****** Polymorphism *****");

Shape[] shapes = { new Hexagon(), new Circle(), new Hexagon(), new Circle(), new Hexagon() };
foreach (var item in shapes)
{
    item.Draw();
}
Console.WriteLine();
ThreeDCircle tdc = new ThreeDCircle();
tdc.Draw();
((Circle)tdc).Draw();
