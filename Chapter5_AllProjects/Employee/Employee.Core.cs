using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    partial class Employee
    {
        public int Id { get; } // set; }
        private string name;
        public string Name
        {
            set { name = value == "" || value == null ? "__PLACEHOLDER__" : value; }
            get { return name; }
        }
        private double pay;
        public double Pay
        {
            set => pay = value >= 0 ? value : 0;
            get => pay;
        }

        public EmployeePayTypeEnum PayType { get; set; }

        public Employee(int id, string name, double pay = 0, EmployeePayTypeEnum payType = EmployeePayTypeEnum.Salaried)
        {
            Id = id;
            Name = name;
            Pay = pay;
            PayType = payType;
        }

    }
}
