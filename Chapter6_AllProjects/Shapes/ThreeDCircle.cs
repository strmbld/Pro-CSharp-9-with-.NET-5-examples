using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class ThreeDCircle : Circle
    {
        public new string Name { get; set; }
        public new void Draw() => Console.WriteLine("Call 3DCircle.Draw()");
    }
}
