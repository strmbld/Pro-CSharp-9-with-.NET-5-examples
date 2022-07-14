using System;

namespace SimpleClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** OOP *****");

            Car mCar = new("Honda", 10);
            mCar.Show();
            for (int i = 0; i < 10; i++)
            {
                mCar.SpeedUp(5);
                mCar.Show();
            }
            Console.WriteLine();
            Car newCar = new();
            newCar.Show();
            Console.WriteLine();
            Car newCar1 = new("BMW");
            newCar1.Show();
            Console.WriteLine();

            bool inDanger1;
            Car nCar1 = new("McLaren", 150, out inDanger1);
            Console.WriteLine(inDanger1);
            Console.WriteLine();

            bool inDanger2;
            Car nCar2 = new("Ferrari", 100, out inDanger2);
            Console.WriteLine(inDanger2);
            Console.WriteLine();

            MotocycleS ms = new(name: "Suzuki");
            Console.WriteLine(ms.Intensity);
            Console.WriteLine();
        }
    }

    class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }

        public Car() { }

        public Car(string name) => Name = name;
        public Car(string name, int speed) : this(name)
        {
            Speed = speed;
        }
        public Car(string name, int speed, out bool inDanger) : this(name, speed)
        {
            //Name = name;
            //Speed = speed;

            inDanger = speed > 100;
        }

        private enum CarColor
        {
            Red, Green, Blue,
        }
        public void SpeedUp(int delta) => Speed += delta;

        public void Show() => Console.WriteLine($"{Name} is going {Speed} MPH");
    }

    class Motocycle
    {
        public int Intensity { get; set; }
        public string Name { get; set; }
        public Motocycle()
        {

        }

        public Motocycle(int intensity) : this(intensity, "")
        {

        }

        public Motocycle(string name) : this(0, name)
        {

        }
        public Motocycle(int intensity, string name)
        {
            Intensity = intensity > 10 ? 10 : intensity;
            Name = name;
        }
    }
    class MotocycleS
    {
        public int Intensity { get; set; }
        public string Name { get; set; }

        public MotocycleS(int intensity = 0, string name = "")
        {
            Intensity = intensity > 10 ? 10 : intensity;
            Name = name;
        }
    }

    class MotocycleES
    {
        public int Intensity { get; set; }
        public string Name { get; set; }
    }
}
