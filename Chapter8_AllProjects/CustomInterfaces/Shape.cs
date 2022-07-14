using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    abstract class Shape
    {
        public string Name { get; set; }

        protected Shape(string name = "NoName")
        { Name = name; }
        public abstract void Draw(); // => Console.WriteLine("Call Shape.Draw()");
    }
}
