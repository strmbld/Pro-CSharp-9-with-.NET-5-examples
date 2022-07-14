using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    abstract partial class Employee
    {
        
        public virtual void GiveBonus(float amount)
        {
            Pay = this switch
            {
                { PayType: EmployeePayTypeEnum.Commission } => Pay += 0.10F * amount,
                { PayType: EmployeePayTypeEnum.Hourly } => Pay += 40F * amount / 2080F,
                { PayType: EmployeePayTypeEnum.Salaried } => Pay += amount,
                _ => Pay += 0
            };
        }

        public virtual void Show()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Pay: {Pay}");
        }

        public double GetBenefitCost() => benefits.ComputePayDeduction();
    }
}
