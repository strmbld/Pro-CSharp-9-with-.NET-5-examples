using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeachExtensionMethods
{
    class Garage
    {
        public Car[] cars { get; set; }
        public Garage()
        {
            cars = new Car[4];
            cars[0] = new("Rusty", 30);
            cars[1] = new("Clunker", 55);
            cars[2] = new("Zippy", 30);
            cars[3] = new("Fred", 30);
        }
    }
}
