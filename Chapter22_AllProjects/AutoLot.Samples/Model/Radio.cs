using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLot.Samples.Model
{
    public class Radio : BaseEntity
    {
        public bool HasTweeter { get; set; }
        public bool HasSubWoofers { get; set; }
        public string RadioId { get; set; }
        public int CarId { get; set; }
        public Car CarNavigation { get; set; }
    }
}
