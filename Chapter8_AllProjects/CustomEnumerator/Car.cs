using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    class Car
    {
        public const int MAXSPEED = 100;
        public int CurrentSpeed { get; set; }
        public string Name { get; set; }
        private bool carIsDead;
        private readonly Radio theMusicBox;

        public Car(string name = "", int currentSpeed = 0)
        {
            CurrentSpeed = currentSpeed;
            Name = name;
            carIsDead = false;
            theMusicBox = new Radio();
        }
        public void CrankTunes(bool state) => theMusicBox.TurnOn(state);
        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                Console.WriteLine($"{Name} => RIP");
                return;
            }
            if (CurrentSpeed + delta > MAXSPEED)
            {
                // Console.WriteLine($"{Name} is overheated! Dropping speed to 0");
                // CurrentSpeed = 0;
                // carIsDead = true;
                // return;
                throw new Exception($"{Name} is overheated! Dropping speed to 0")
                { 
                    HelpLink = "http://www.CarsRUs.com",
                    Data =
                    {
                        {"TimeStamp", $"The car exploded at {DateTime.Now}" },
                        {"Cause", "That was plan" },
                    },
                };
            }
            CurrentSpeed += delta;
            Console.WriteLine($"CurrentSpeed = {CurrentSpeed}");
        }
    }
}
