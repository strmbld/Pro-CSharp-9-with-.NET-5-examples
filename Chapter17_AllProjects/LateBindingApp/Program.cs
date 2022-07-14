using System;
using System.IO;
using System.Reflection;

Assembly assembly = null;
try
{
    assembly = Assembly.LoadFrom("CarLibrary");
}
catch (FileNotFoundException e)
{
    Console.WriteLine(e.Message);
    return;
}
if (assembly !=null)
{
    InstantiateViaLB(assembly);
}


void InstantiateViaLB(Assembly assembly)
{
    try
    {
        Type miniVan = assembly.GetType("CarLibrary.MiniVan");
        object obj = Activator.CreateInstance(miniVan);
        Console.WriteLine($"Created {obj}");
        MethodInfo mi = miniVan.GetMethod("TurboBoost");
        mi.Invoke(obj, null);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}