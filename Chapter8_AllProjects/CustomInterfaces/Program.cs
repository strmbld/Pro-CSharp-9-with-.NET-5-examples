using System;
using CustomInterfaces;

Console.WriteLine("***** Interfaces *****");
CloneableExample();

Hexagon h = new("hexagon");
Console.WriteLine($"{h.Name}, {h.Points}");

Hexagon hex2 = new("hex2");
IPointy hex2pointy = hex2 as IPointy;
if (hex2pointy != null)
{
    Console.WriteLine($"hex2 points: {hex2pointy.Points}");
}
else
{
    Console.WriteLine($"not supported");
}

Circle c = new("circle");
if (c is IPointy cPointy)
{
    Console.WriteLine($"circle points: {cPointy.Points}");
}
else
{
    Console.WriteLine($"IPointy not supported");
}

Shape[] shapes = { new Hexagon(), new Circle(), new Triangle(), new Circle() };
foreach (Shape item in shapes)
{
    if (item is IDraw3D s3d)
    {
        DrawIn3D(s3d);
    }
}

IPointy firstIPointy = FindFirstPointyShape(shapes);
Console.WriteLine($"found; number of points: {firstIPointy?.Points}");

IPointy[] iPointyObjects = { new Hexagon(), new Knife(), new Triangle(), new Fork(), new PitchFork() };
foreach (IPointy i in iPointyObjects)
{
    Console.WriteLine($"Obj has {i.Points} points");
}

static IPointy FindFirstPointyShape(Shape[] shapes)
{
    foreach(Shape s in shapes)
    {
        if (s is IPointy ips)
        {
            return ips;
        }
    }
    return null;
}
static void DrawIn3D(IDraw3D shape3d)
{
    Console.WriteLine("Drawing anything supporting IDraw3D interface");
    shape3d.Draw3D();
}

static void CloneableExample()
{
    string s = "hello";
    OperatingSystem unix = new OperatingSystem(PlatformID.Unix, new Version());
    CloneMe(s);
    CloneMe(unix);
    static void CloneMe(ICloneable c)
    {
        object theClone = c.Clone();
        Console.WriteLine($"Cloned object: {theClone.GetType().Name}");
    }
}
