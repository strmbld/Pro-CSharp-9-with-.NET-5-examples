using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }
        public SalesPerson() { }
        public SalesPerson(string name, int age, int id, float currPay, string ssn, int numbOfSales)
            : base(name, age, id, currPay, ssn, EmployeePayTypeEnum.Commission)
        {
            SalesNumber = numbOfSales;
        }
        public override sealed void GiveBonus(float amount)
        {
            int salesBonus = 0;
            if (SalesNumber >= 0 && SalesNumber <= 100)
            {
                salesBonus = 10;
            }
            else if (SalesNumber >= 101 && SalesNumber <= 200)
            {
                salesBonus = 15;
            }
            else salesBonus = 20;

            base.GiveBonus(amount * salesBonus);
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Number of sales: {SalesNumber}");
        }
    }
}
