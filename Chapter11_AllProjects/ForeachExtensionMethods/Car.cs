using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeachExtensionMethods
{
    class Car
    {
        public int Speed { get; set; }
        public string Name { get; set; }
        public Car() { }

        public Car(int speed, string name)
        {
            Speed = speed;
            Name = name;
        }
        public Car(string name, int speed)
        {
            Speed = speed;
            Name = name;
        }
    }
}
