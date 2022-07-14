using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    class Square : Shape, IRegularPointy
    {
        public Square() { }
        public Square(string name) : base(name) { }
        public int SideLength { get; set; } // from IRegularPointy
        public int NumOfSides { get; set; } // from IRegularPointy

        public byte Points => 4; // from IPointy

        public override void Draw() => Console.WriteLine("Call Square.Draw()");
        // Perimeter from IRegularPointy is not implemented and default implementation is used
        // to use it should do explicit cast ((IRegularPointy)square_inst).Perimeter
    }
}
