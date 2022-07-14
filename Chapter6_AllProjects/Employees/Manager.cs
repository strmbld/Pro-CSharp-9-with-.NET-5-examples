using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Manager : Employee
    {
        public int StockOptions { get; set; }
        public Manager() { }
        public Manager(string name, int age, int id, float currPay, string ssn, int numbOfOpts)
            : base(name,age,id,currPay,ssn,EmployeePayTypeEnum.Salaried)
        {
            StockOptions = numbOfOpts;
        }
        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            StockOptions += new Random().Next(500);
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"StockOptions: {StockOptions}");
        }
    }
}
