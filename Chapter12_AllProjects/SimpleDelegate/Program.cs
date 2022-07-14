using System;
using SimpleDelegate;

BinaryOp b = new(SimpleMath.Add);
Console.WriteLine(b(10,10));
ShowDelegateInfo(b);
Console.WriteLine();

SimpleMath sm = new SimpleMath();
BinaryOp b1 = new(sm.Subtract);
Console.WriteLine(b1(100, 10));
ShowDelegateInfo(b1);
Console.WriteLine();

static void ShowDelegateInfo(Delegate del)
{
    foreach (Delegate d in del.GetInvocationList())
    {
        Console.WriteLine($"Method: {d.Method}");
        Console.WriteLine($"Target (object): {d.Target}");
    }
}

public delegate int BinaryOp(int x, int y);
