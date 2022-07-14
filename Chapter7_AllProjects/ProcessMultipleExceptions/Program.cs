using System;
using System.IO;
using ProcessMultipleExceptions;

Console.WriteLine("***** Handling Multiple Exceptions *****");
Car car1 = new("Rusty", 90);
try
{
    car1.Accelerate(-10);
}
catch (CarIsDeadException e) when (e.ErrorTimeStamp.DayOfWeek != DayOfWeek.Friday)
{
    Console.WriteLine(e.Message);
    try
    {
        FileStream fs = null; // open blabla
    }
    catch (Exception e2)
    {
        // e.InnerException = e2; compile error readonly prop
        throw new CarIsDeadException(e.CauseOfError, e.Message, e2);
    }
}
catch(ArgumentOutOfRangeException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.TargetSite);
}
catch (Exception e){ Console.WriteLine(e.Message); }
finally { car1.CrankTunes(false); }