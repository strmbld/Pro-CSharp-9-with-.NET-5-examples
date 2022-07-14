using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicDelegateProblem
{
    class Car
    {
        public delegate void CarEngineHandler(string msg);
        public CarEngineHandler callbacks; // keep private
        public void Accelerate(int delta)
        {
            if (callbacks != null)
            {
                callbacks("car is dead");
            }
        }
    }
}
