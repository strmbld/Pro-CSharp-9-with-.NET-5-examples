using System;
using System.Linq;
using System.Reflection;

string input = "";

do
{
    Console.WriteLine("Enter type name; type Q for exit");
    Console.WriteLine("Examples for generics:");
    Console.WriteLine("System.Collections.Generic.List`1; System.Collections.Generic.Dictionary`2");
    input = Console.ReadLine();
    if (input.ToLower().Trim().Equals("q", StringComparison.OrdinalIgnoreCase))
    {
        return;
    }

    Type t = Type.GetType(input);
    if (t == null)
    {
        if (input.Equals("System.Console", StringComparison.OrdinalIgnoreCase))
        {
            t = typeof(System.Console); // have to use typeof for static types
        }
        else
        {
            Console.WriteLine("Wrong input");
            continue;
        }   
    }
    Console.WriteLine();
    LsExtra(t);
    LsFields(t);
    LsProps(t);
    LsMethods(t);
    LsInterfaces(t);
    Console.WriteLine();

} while (true);

static void LsMethods(Type t)
{
    Console.WriteLine("***** Methods *****");
    var methodNames = from n in t.GetMethods() select n;
    foreach (var name in methodNames)
    {
        Console.WriteLine("->{0}", name);
    }
    Console.WriteLine();

    Console.WriteLine("*** Methods ***");
    MethodInfo[] mi = t.GetMethods();
    foreach (MethodInfo method in mi)
    {
        string retVal = method.ReturnType.FullName;
        string paramInfo = "( ";
        foreach (ParameterInfo parameterInfo in method.GetParameters())
        {
            paramInfo += string.Format($"{parameterInfo.ParameterType} {parameterInfo.Name}");
            paramInfo += " ";
        }
        paramInfo += ")";
        Console.WriteLine($"-> {retVal} {method.Name} {paramInfo}");
    }
    Console.WriteLine();
}
static void LsFields(Type t)
{
    Console.WriteLine("*** Fields ***");
    var fieldNames = from f in t.GetFields() select f.Name;
    foreach (var name in fieldNames)
    {
        Console.WriteLine($"-> {name}");
    }
    Console.WriteLine();
}
static void LsProps(Type t)
{
    Console.WriteLine("*** Properties ***");
    var propNames = from p in t.GetProperties() select p.Name;
    foreach (var name in propNames)
    {
        Console.WriteLine($"-> {name}");
    }
    Console.WriteLine();
}
static void LsInterfaces(Type t)
{
    Console.WriteLine("*** Interfaces ***");
    var iNames = from i in t.GetInterfaces() select i.Name;
    foreach (var name in iNames)
    {
        Console.WriteLine($"-> {name}");
    }
    Console.WriteLine();
}
static void LsExtra(Type t)
{
    Console.WriteLine("*** Extra ***");
    Console.WriteLine($"Base: {t.BaseType}");
    Console.WriteLine($"Abstract: {t.IsAbstract}");
    Console.WriteLine($"Sealed: {t.IsSealed}");
    Console.WriteLine($"Generic: {t.IsGenericTypeDefinition}");
    Console.WriteLine($"IsClass: {t.IsClass}");
    Console.WriteLine();
}
