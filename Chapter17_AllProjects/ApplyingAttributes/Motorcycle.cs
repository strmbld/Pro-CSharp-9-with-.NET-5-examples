using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace ApplyingAttributes
{
    [XmlRoot(Namespace = "http://www.MyCompany.com")]
    [Obsolete("Use something safer")]
    public class Motorcycle
    {
        [JsonIgnore]
        public float weightOfCurrentPassengers;
        public bool hasRadio;
        public bool hasHeadSet;
    }
}
