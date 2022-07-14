using System;
using System.Reflection;

ReflectAttrViaLB();

static void ReflectAttrViaLB()
{
    try
    {
        Assembly assembly = Assembly.LoadFrom("AttributedCarLibrary");
        Type vehicleDesc = assembly.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");
        PropertyInfo propDesc = vehicleDesc.GetProperty("Description");

        Type[] types = assembly.GetTypes();
        foreach (Type type in types)
        {
            object[] objs = type.GetCustomAttributes(vehicleDesc, false);
            foreach (object o in objs)
            {
                Console.WriteLine($"-> {type.Name}: {propDesc.GetValue(o, null)}");
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}