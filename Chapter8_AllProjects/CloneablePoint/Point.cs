using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point() { }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"X = {X}; Y = {Y}";
        }

        public object Clone() // or public object Clone() => this.MemberwiseClone()  while class doesn't contain ref types
            // in presence of ref types should use combination of MemberwiseClone() and manual allocation new ref types objects in clone
        {
            return new Point(X, Y);
        }
    }
}
