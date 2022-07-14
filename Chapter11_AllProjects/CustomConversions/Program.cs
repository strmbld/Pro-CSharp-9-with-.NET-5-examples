using System;
using CustomConversions;

Rectangle r = new(15, 4);
Console.WriteLine(r);
r.Draw();
Console.WriteLine();

Square s = (Square)r;
Console.WriteLine(s);
s.Draw();
Console.WriteLine();

Square s3 = new(7);
Rectangle r2 = s3;
Console.WriteLine(r2);
r2.Draw();
Console.WriteLine();

Rectangle r3 = (Rectangle)s3;
Console.WriteLine(r3);
r3.Draw();
Console.WriteLine(r2==r3);
