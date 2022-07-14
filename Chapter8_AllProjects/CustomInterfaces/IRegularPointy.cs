using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    interface IRegularPointy : IPointy
    {
        int SideLength { get; set; }
        int NumOfSides { get; set; }
        int Perimeter => SideLength * NumOfSides;
        static string ExampleProp { get; set; }
        static IRegularPointy() => ExampleProp = "Foo";
    }
}
