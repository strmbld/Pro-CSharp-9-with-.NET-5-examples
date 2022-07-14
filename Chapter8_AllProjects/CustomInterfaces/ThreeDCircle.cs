using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    class ThreeDCircle : Circle, IDraw3D
    {
        public new string Name { get; set; }
        public new void Draw() => Console.WriteLine("Call 3DCircle.Draw()");
        public void Draw3D() => Console.WriteLine("Call 3DCircle.Draw3D()");
    }
}
