using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitialization
{
    class PointInitOnlySetters
    {
        public int X { get; init; }
        public int Y { get; init; }

        public PointInitOnlySetters(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Show() => Console.WriteLine($"{X}, {Y}");
    }
}
