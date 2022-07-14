using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    public class SavingsAccount
    {
        public static double CurrInterestRate { get; set; } // = (new Random()).NextDouble();
        public double Balance { get; set; }

        static SavingsAccount()
        {
            Console.WriteLine("static ctor called");
            CurrInterestRate = 0.04;
        }
        public SavingsAccount(double balance)
        { 
            Balance = balance;
        }

    }
}
