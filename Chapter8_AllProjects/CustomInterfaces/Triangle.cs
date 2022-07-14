using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    class Triangle : Shape, IPointy
    {
        public byte Points => 3;
        public Triangle() { }
        public Triangle(string name) : base(name) { }

        public override void Draw() => Console.WriteLine($"Drawing {Name} the triangle");
        
    }
}
