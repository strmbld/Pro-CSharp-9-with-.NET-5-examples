using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumeratorWithYeild
{
    public class Garage : IEnumerable
    {
        private Car[] arr = new Car[4];
        public Garage()
        {
            arr[0] = new("Rusty", 30);
            arr[1] = new("Clunker", 55);
            arr[2] = new("Zippy", 30);
            arr[3] = new("Fred", 30);
        }

        // public IEnumerator GetEnumerator() => arr.GetEnumerator();
        // IEnumerator IEnumerable.GetEnumerator() => arr.GetEnumerator(); // implicitly private, foreach still works
        public IEnumerator GetEnumerator()
        {
            // throw new Exception("called");
            return Implementation();
            IEnumerator Implementation()
            {
                foreach (Car c in arr)
                {
                    yield return c;
                }
            }
        }

        public IEnumerable GetTheCars(bool reversed)
        {
            // __validation__
            return Implementation();
            IEnumerable Implementation()
            {
                if (reversed)
                {
                    for (int i = arr.Length; i != 0; i--)
                    {
                        yield return arr[i - 1];
                    }
                }
                else
                {
                    foreach (Car c in arr)
                    {
                        yield return c;
                    }
                }
            }
        }
    }
}
