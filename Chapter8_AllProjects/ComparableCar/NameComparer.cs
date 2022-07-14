using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar
{
    class NameComparer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            if (x is Car c1 && y is Car c2)
            {
                return string.Compare(c1.Name, c2.Name, StringComparison.OrdinalIgnoreCase);
            }
            throw new ArgumentException("Parameter is not Car");
        }
    }
}
