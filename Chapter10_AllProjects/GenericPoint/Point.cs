using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPoint
{
    struct Point<T>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }
        public void Reset()
        {
            // X = default(T);
            // Y = default(T);
            X = default;
            Y = default;
        }
        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
    }
}
