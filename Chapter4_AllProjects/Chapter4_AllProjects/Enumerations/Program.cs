using System;

namespace Enumerations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** enum *****");

            int x = (int)EmpTypeEnum.Contractor;
            Console.WriteLine(x);
            Console.WriteLine();
            Console.WriteLine(Enum.GetUnderlyingType(EmpTypeEnum.Contractor.GetType()));
            Console.WriteLine(Enum.GetUnderlyingType(typeof(EmpTypeEnum)));
            EmpTypeEnum emp = EmpTypeEnum.Contractor;
            Console.WriteLine($"emp is: {emp.ToString()}");
            Console.WriteLine($"emp is: {emp.ToString()} = {(byte)emp}"); // there is also Enum.Format()
            Console.WriteLine();

            EvalEnum(emp);
            Console.WriteLine();
            EvalEnum(DayOfWeek.Monday);
            Console.WriteLine();
            EvalEnum(ConsoleColor.Red);
            Console.WriteLine();
        }

        static void EvalEnum(Enum e)
        {
            Type eType = e.GetType();

            Console.WriteLine($"Information about {eType.Name}");

            Console.WriteLine($"Underlying storage type: {Enum.GetUnderlyingType(eType)}");

            Array enumData = Enum.GetValues(eType);
            Console.WriteLine($"Enum members number: {enumData.Length}");
            Console.WriteLine("Enum members:");
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine($"Name: {enumData.GetValue(i)}, Value: {enumData.GetValue(i):D}");
            }
        }

        enum EmpTypeEnum : byte // default 0,1,2,3 but possible to start with something else just assign val to first member
            // anyway possible to use enum without sequential ordering but specifically assigned values n+1 still applies if not specified
        {
            Manager = 102,
            Grunt,
            Contractor = 254, // compile error with 255+ values since restricted to specified 'byte' type
            VicePresident,
        }
    }
}
