using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using System.Runtime.CompilerServices;

// [assembly:InternalsVisibleTo("CSharpCarClient")]

namespace CarLibrary
{
    public abstract class Car
    {
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int Speed { get; set; }

        protected EngineStateEnum state;
        public EngineStateEnum EngineState => state;

        protected Car() { }
        protected Car(string name, int maxSpeed, int speed)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            Speed = speed;
            state = EngineStateEnum.EngineAlive;
        }

        public abstract void TurboBoost();
    }
}
