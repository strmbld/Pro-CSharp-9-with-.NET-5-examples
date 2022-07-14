using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLot.Dal.BulkCopy
{
    public interface IALotDataReader<T> : IDataReader
    {
        List<T> Records { get; set; }
    }
}
