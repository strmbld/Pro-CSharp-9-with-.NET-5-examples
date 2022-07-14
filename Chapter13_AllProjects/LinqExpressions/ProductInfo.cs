using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExpressions
{
    class ProductInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }
        public override string ToString()
        {
            return $"Name={Name}, Description={Description}, UnitsInStock={UnitsInStock}";
        }
    }
}
