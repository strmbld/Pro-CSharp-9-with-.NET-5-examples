using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSerialize
{
    public class Car
    {
        public Radio radio;
        public bool isHatchback;
        public Car()
        {
            radio = new Radio();
        }
        public override string ToString()
        {
            return $"IsHatchback:{isHatchback} Radio:{radio}";
        }
    }
}
