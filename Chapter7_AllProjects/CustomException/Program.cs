using System;
using CustomException;

Console.WriteLine("***** Custom Exception *****");
Car car1 = new("Rusty", 90);
try
{
    car1.Accelerate(50);
}
catch (CarIsDeadException e) // may upcast to System.Exception
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.ErrorTimeStamp);
    Console.WriteLine(e.CauseOfError);
}
Console.WriteLine();
