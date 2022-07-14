using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    abstract partial class Employee
    {
        public int Id { get; init; } // set; }
        private string name;
        public string Name
        {
            set { name = value == "" || value == null ? "__PLACEHOLDER__" : value; }
            get { return name; }
        }
        private float pay;
        public float Pay
        {
            set => pay = value >= 0 ? value : 0;
            get => pay;
        }

        public EmployeePayTypeEnum PayType { get; set; }

        public int Age { get; set; }
        public string SSN { get; set; }
        protected BenefitPackage benefits = new BenefitPackage();

        protected class BenefitPackage1
        {
            public enum BenefitPackageLevel
            { Standard, Gold, Platinum }
            public double ComputePayDeduction() => 125.0;
        }

        public BenefitPackage Benefits
        {
            get { return benefits; }
            set { benefits = value; }
        }

        public Employee() { }
        public Employee(string name, int age, int id, float pay, string ssn, EmployeePayTypeEnum payType)
        {
            Name = name;
            Id = id;
            Age = age;
            Pay = pay;
            SSN = ssn;
            PayType = payType;
        }

    }
}
