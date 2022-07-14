using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGC
{
    class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        
        public Car() { }

        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }
        public override string ToString()
        {
            return $"{Name}is going {Speed} MPH";
        }
        
    }
}
