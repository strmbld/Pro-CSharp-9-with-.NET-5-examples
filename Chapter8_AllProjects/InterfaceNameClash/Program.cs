using System;
using InterfaceNameClash;

Console.WriteLine("***** Interface Name Clashes *****");

Octagon oct = new Octagon();
((IDrawToPrinter)oct).Draw();
if (oct is IDrawToMemory dtm)
{
    dtm.Draw();
}
IDrawToForm octForm = (IDrawToForm)oct;
octForm.Draw();
