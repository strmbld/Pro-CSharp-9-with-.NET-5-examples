using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributedCarLibrary
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; }
        public VehicleDescriptionAttribute() { }
        public VehicleDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
