using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIndexer
{
    class PersonCollectionStringIndexer : IEnumerable
    {
        private Dictionary<string, Person> d = new();
        public Person this[string name]
        {
            get => d[name];
            set => d[name] = value;
        }
        public void Clear() => d.Clear();
        public int Count => d.Count;
        public IEnumerator GetEnumerator() => d.GetEnumerator();
    }
}
