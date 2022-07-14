using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    class Hexagon : Shape, IPointy, IDraw3D
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw() => Console.WriteLine("Call Hexagon.Draw()");
        public byte Points => 6;
        public void Draw3D() => Console.WriteLine("Call Hexagon.Draw3D()");
    }
}
