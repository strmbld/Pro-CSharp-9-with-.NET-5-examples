using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleSerialize
{
    public class JamesBondCar : Car
    {
        [XmlAttribute]
        public bool canFly;
        [XmlAttribute]
        public bool canSubmerge;
        public JamesBondCar() { }
        public override string ToString()
        {
            return $"CanFly:{canFly}, CanSubmerge:{canSubmerge} {base.ToString()}";
        }

    }
}
