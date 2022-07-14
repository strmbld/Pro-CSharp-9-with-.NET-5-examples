using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSerialize
{
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubwoofers;
        public List<double> stationPresets;
        public string id;
        public Radio()
        {
            id = "XF-552RR6";
        }
        public override string ToString()
        {
            var presets = string.Join(",", stationPresets.Select(i => i.ToString()).ToList());
            return $"HasTweeters:{hasTweeters} HasSubwoofers:{hasSubwoofers} Station presets:{presets}";
        }
    }
}
