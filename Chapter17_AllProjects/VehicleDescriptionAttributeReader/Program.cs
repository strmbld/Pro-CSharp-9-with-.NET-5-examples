using System;
using AttributedCarLibrary;

ReflectAttrViaEB();

static void ReflectAttrViaEB()
{
    Type t = typeof(Winnebago);
    object[] customAttrs = t.GetCustomAttributes(false);
    foreach (VehicleDescriptionAttribute v in customAttrs) Console.WriteLine($"-> {v.Description}");
}