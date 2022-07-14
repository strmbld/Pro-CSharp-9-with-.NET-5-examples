using System;

namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Employee emp = new(1, "", -300);
            emp.Show();
            Console.WriteLine();
            emp.GiveBonus(420);
            emp.Show();
            Console.WriteLine();
            Employee emp2 = new(2, "", 300, EmployeePayTypeEnum.Commission);
            emp2.Show();
            Console.WriteLine();
            emp2.GiveBonus(1000);
            emp2.Show();
            Console.WriteLine();
        }
    }
}
