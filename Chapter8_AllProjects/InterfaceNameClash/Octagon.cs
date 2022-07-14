using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        // public void Draw() => Console.WriteLine("Call Octagon.Draw()");
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Octagon Draw to form");
        }

        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Octagon Draw to memory");
        }

        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Octagon Draw to printer");
        }
    }
}
