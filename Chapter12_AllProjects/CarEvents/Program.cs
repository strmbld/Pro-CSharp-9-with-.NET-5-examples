using System;
using CarEvents;

// NameOfObject.NameOfEvent += new related_delegate(method)
// Car.CarEngineHandler ceh = new Car.CarEngineHandler(callback);
// car.Exploded += ceh;

// NameOfObject.NameOfEvent -= new related_delegate(callback);
// car.Exploded -= ceh;

// Car.CarEngineHandler ceh = Method;
// car.Exploded += ceh;

Car c1 = new("Jaguar", 100, 10);

c1.AboutToBlow += CarIsCar;
c1.AboutToBlow += CarAboutToBlow;
c1.Exploded += CarDead;

for (int i = 0; i < 6; i++)
{
    c1.Accelerate(20);
}
c1.Exploded -= CarDead;
for (int i = 0; i < 6; i++)
{
    c1.Accelerate(20);
}
Console.WriteLine();

// EventHandler<CarEventArgs> h = CarDead;
// c1.Exploded += h;

static void CarAboutToBlow(object sender, CarEventArgs args) => Console.WriteLine($"{sender} says: {args.message}");
static void CarIsCar(object sender, CarEventArgs args) => Console.WriteLine($"{sender} says: {args.message}");
static void CarDead(object sender, CarEventArgs args)
{
    Console.WriteLine($"{sender} says: {args.message}");
    if (sender is Car c)
    {
        Console.WriteLine($"{c.Name} is dead");
    }
}
