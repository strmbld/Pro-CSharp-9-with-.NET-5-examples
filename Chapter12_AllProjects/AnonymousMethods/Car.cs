using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethods
{
    class Car
    {
        private bool carIsDead;
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int Speed { get; set; } 
        public Car() { }
        public Car(string name, int maxSpeed, int speed)
        {
            carIsDead = false;
            Name = name;
            MaxSpeed = maxSpeed;
            Speed = speed;
        }
        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                Exploded?.Invoke(this, new CarEventArgs("Car is ripperino"));
                return;
            }
            Speed += delta;
            if (Speed >= MaxSpeed)
            {
                carIsDead = true;
                return;
            }
            if ((MaxSpeed - Speed) <= 10)
            {
                AboutToBlow?.Invoke(this, new CarEventArgs($"{MaxSpeed - Speed} MPH till blow"));
                listOfHandlers?.Invoke(this, new CarEventArgs($"Current speed = {Speed}"));
                return;
            }
            Console.WriteLine($"Current speed = {Speed}");
        }
        public delegate void CarEngineHandler(object sender, CarEventArgs args);
        private CarEngineHandler listOfHandlers;
        public void RegisterCallback(CarEngineHandler method) => listOfHandlers += method; // += calls => listOfHandlers = Delegate.Combine(listOfHandlers, methods) as CarEngineHandler
        public void UnregisterCallback(CarEngineHandler method) => listOfHandlers -= method; // -= calls Delegate.Remove()

        // public event CarEngineHandler Exploded;
        // public event CarEngineHandler AboutToBlow;
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;
    }
}
