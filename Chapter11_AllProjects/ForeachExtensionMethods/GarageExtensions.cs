using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeachExtensionMethods
{
    static class GarageExtensions
    {
        public static IEnumerator GetEnumerator(this Garage g) => g.cars.GetEnumerator();
    }
}
