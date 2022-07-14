using System;
using System.Reflection;
using System.Linq;

string input = "";
Assembly assembly = null;

do
{
    Console.WriteLine("Type assembly name or q for exit");
    input = Console.ReadLine();
    if (input.Trim().ToLower().Equals("q", StringComparison.OrdinalIgnoreCase)) return;
    try
    {
        assembly = Assembly.LoadFrom(input);
    }
    catch
    {
        Console.WriteLine("wrong input");
        continue;
    }
    if (assembly == null)
    {
        Console.WriteLine("wrong input");
        continue;
    }
    AssemblyDisplayTypes(assembly);
} while (true);

static void AssemblyDisplayTypes(Assembly assembly)
{
    Console.WriteLine("*** Types in Assembly ***");
    Console.WriteLine($"-> {assembly.FullName}");
    var types = from t in assembly.GetTypes() select t;
    foreach (var t in types) Console.WriteLine($"Type: {t}");
    Console.WriteLine();
}