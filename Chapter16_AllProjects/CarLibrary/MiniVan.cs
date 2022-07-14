using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class MiniVan : Car
    {
        public MiniVan() { }
        public MiniVan(string name, int maxSpeed, int speed) : base(name, maxSpeed, speed)
        {
        }

        public override void TurboBoost()
        {
            state = EngineStateEnum.EngineDead;
            Console.WriteLine("Engine exploded; called MiniVan.TurboBoost()");
        }
    }
}
