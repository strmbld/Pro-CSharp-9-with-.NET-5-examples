using System;
using ComparableCar;

Car[] cars = new Car[5];
cars[0] = new Car(1, "Rusty", 80);
cars[1] = new Car(234, "Mary", 40);
cars[2] = new Car(34, "Viper", 40);
cars[3] = new Car(4, "Mel", 40);
cars[4] = new Car(5, "Chucky", 40);
Array.Sort(cars);
foreach (Car c in cars)
{
    Console.WriteLine($"id: {c.Id}, Name: {c.Name}");
}
Console.WriteLine();
Array.Sort(cars, new NameComparer());
foreach(Car c in cars)
{
    Console.WriteLine($"id: {c.Id}, Name: {c.Name}");
}
Console.WriteLine();
Array.Sort(cars, Car.SortByName);
foreach (Car c in cars)
{
    Console.WriteLine($"id: {c.Id}, Name: {c.Name}");
}