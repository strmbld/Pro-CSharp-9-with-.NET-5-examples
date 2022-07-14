using System;
using InterfaceHierarchy;

Console.WriteLine("***** Interface Hierarchy *****");

BitmapImage bmp = new BitmapImage();
bmp.Draw();
bmp.DrawInBoundingBox(10, 10, 100, 150);
bmp.DrawUpsideDown();
if (bmp is IAdvancedDraw iAdvD)
{
    iAdvD.DrawUpsideDown();
    Console.WriteLine($"Time to draw: {iAdvD.TimeToDraw()}");
}
Console.WriteLine();

Console.WriteLine(bmp.TimeToDraw());
Console.WriteLine(((IDrawable)bmp).TimeToDraw());
Console.WriteLine(((IAdvancedDraw)bmp).TimeToDraw());
