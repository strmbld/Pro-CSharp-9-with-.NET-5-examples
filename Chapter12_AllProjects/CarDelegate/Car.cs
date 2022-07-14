using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
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
                listOfHandlers?.Invoke("Car is ripperino");
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
                listOfHandlers?.Invoke($"{MaxSpeed - Speed} MPH till blow");
                listOfHandlers?.Invoke($"Current speed = {Speed}");
                return;
            }
            Console.WriteLine($"Current speed = {Speed}");
        }
        public delegate void CarEngineHandler(string msgForClient);
        private CarEngineHandler listOfHandlers;
        public void RegisterCallback(CarEngineHandler method) => listOfHandlers += method; // += calls => listOfHandlers = Delegate.Combine(listOfHandlers, methods) as CarEngineHandler
        public void UnregisterCallback(CarEngineHandler method) => listOfHandlers -= method; // -= calls Delegate.Remove()
    }
}
