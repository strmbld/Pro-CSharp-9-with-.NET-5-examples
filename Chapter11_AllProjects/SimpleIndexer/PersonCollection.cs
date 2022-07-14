using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIndexer
{
    class PersonCollection : IEnumerable
    {
        private ArrayList arr = new();
        public Person this[int i]
        {
            get => (Person)arr[i];
            set => arr.Insert(i, value);
        }
        public Person GetPerson(int pos) => (Person)arr[pos];
        public void AddPerson(Person p) => arr.Add(p);
        public void Clear() => arr.Clear();
        public int Count => arr.Count;
        public IEnumerator GetEnumerator() => arr.GetEnumerator();
        
    }
}
