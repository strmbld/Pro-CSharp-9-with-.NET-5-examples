using System;
using static StaticDataAndMembers.TimeUtil;

namespace StaticDataAndMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** static keyword *****");

            SavingsAccount s1 = new SavingsAccount(50);
            SavingsAccount s2 = new SavingsAccount(100);
            SavingsAccount s3 = new SavingsAccount(10000.75);

            Console.WriteLine(SavingsAccount.CurrInterestRate);
            
            SavingsAccount.CurrInterestRate = 0.05;
            Console.WriteLine(SavingsAccount.CurrInterestRate);
            Console.WriteLine();

            PrintDate();
            PrintTime();
            Console.WriteLine();
        }

    }

    class Test : SavingsAccount
    {
        public Test(double balance) : base(balance)
        {
        }
    }
}
