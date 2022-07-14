using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleSerialize
{
    public class Person
    {
        public bool isAlive;
        private int age;
        public string Name { get; set; }
        public Person()
        {
            isAlive = true;
            age = 21;
        }
        public override string ToString()
        {
            return $"IsAlive:{isAlive} Name:{Name} Age:{age}";
        }
    }
}
