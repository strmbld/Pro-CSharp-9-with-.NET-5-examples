using System;
using System.Linq;
using System.Reflection;

var displayName = "Microsoft.EntityFrameworkCore, Version=5.0.0.0, Culture=\"\", PublicKeyToken=adb9793829ddae60";
Assembly assembly = Assembly.Load(displayName);
ShowInfo(assembly);
Console.WriteLine();

static void ShowInfo(Assembly a)
{
    Console.WriteLine("*** Assembly info ***");
    Console.WriteLine($"Name: {a.GetName().Name}");
    Console.WriteLine($"Version: {a.GetName().Version}");
    Console.WriteLine($"Culture: {a.GetName().CultureInfo.DisplayName}");
    Console.WriteLine("Public enums: ");
    Type[] types = a.GetTypes();
    var pubEnums = from pe in types where pe.IsEnum && pe.IsPublic select pe;
    foreach (var pe in pubEnums) Console.WriteLine(pe);
}