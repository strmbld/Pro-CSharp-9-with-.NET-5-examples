using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    class Person
    {
        // something unique for GetHashCode and Equals override
        public string SSN { get; init; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Person() { }

        public Person(string name, int age, string ssn)
        {
            Name = name;
            Age = age;
            SSN = ssn;
        }
        public override string ToString() => $"[Name: {Name}; Age: {Age}]";
        /**
        public override bool Equals(object obj)
        {
            if (!(obj is Person temp))
            {
                return false;
            }
            return Name == temp.Name && Age == temp.Age;
        }*/
        public override bool Equals(object obj) => obj?.ToString() == ToString();
        public override int GetHashCode() => SSN.GetHashCode(); // or ToString().GetHashCode() if no suitable prop
        

    }
}
