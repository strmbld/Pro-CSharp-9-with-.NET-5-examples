using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class SportsCar : Car
    {
        public SportsCar() { }
        public SportsCar(string name, int maxSpeed, int speed) : base(name, maxSpeed, speed)
        {
        }

        public override void TurboBoost()
        {
            Console.WriteLine("Increasing speed; called SportsCar.TurboBoost()");
        }
    }
}
