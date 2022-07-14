using System;
using System.Collections;
using SimpleException;

Console.WriteLine("***** Exceptions *****");
Console.WriteLine("Creating a car and letsfckingo");
Car car1 = new("Zippy", 20);
car1.CrankTunes(true);
try
{
    for (int i = 0; i < 10; i++)
    {
        car1.Accelerate(10);
    }
}
catch (Exception e)
{
    Console.WriteLine("Error occured");
    Console.WriteLine($"Method/Member name: {e.TargetSite}");
    Console.WriteLine($"Member Class: {e.TargetSite.DeclaringType}");
    Console.WriteLine($"Member type: {e.TargetSite.MemberType}");
    Console.WriteLine($"Message: {e.Message}");
    Console.WriteLine($"Source: {e.Source}");
    Console.WriteLine($"StackTrace: {e.StackTrace}");
    Console.WriteLine($"HelpLink: {e.HelpLink}");
    Console.WriteLine("Data:");
    foreach (DictionaryEntry de in e.Data)
    {
        Console.WriteLine($"-> {de.Key}: {de.Value}");
    }
}
Console.WriteLine("Exception handled");
Console.WriteLine();
