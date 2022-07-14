using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    partial class Employee
    {
        
        public void GiveBonus(double amount)
        {
            Pay = this switch
            {
                { PayType: EmployeePayTypeEnum.Commission } => Pay += 0.10D * amount,
                { PayType: EmployeePayTypeEnum.Hourly } => Pay += 40D * amount / 2080D,
                { PayType: EmployeePayTypeEnum.Salaried } => Pay += amount,
                _ => Pay += 0
            };
        }

        public void Show()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Pay: {Pay}");
        }
    }

    public enum EmployeePayTypeEnum
    {
        Hourly, Salaried, Commission,
    }
}
