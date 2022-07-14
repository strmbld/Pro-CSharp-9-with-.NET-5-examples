using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstFields
{
    class MathClass
    {
        public const double PI = 3.1415926; // don't need static cuz const is already implicitly static
    }

    class MathClassMod
    {
        public readonly double PI; // not static; for each instance

        public MathClassMod()
        {
            PI = 3.14;
        }
    }

    class MathClassMod2
    {
        public static readonly double PI = 3.14;
    }

    class MathClassMod3
    {
        public static readonly double Data;

        static MathClassMod3()
        {
            // fetch data in runtime
            Data = 3.333333333;
        }
    }
}
