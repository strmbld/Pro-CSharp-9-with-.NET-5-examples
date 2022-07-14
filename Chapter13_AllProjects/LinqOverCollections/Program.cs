using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using LinqOverCollections;

List<Car> cars = new List<Car>() {
 new Car{ Name = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
 new Car{ Name = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
 new Car{ Name = "Mary", Color = "Black", Speed = 55, Make = "VW"},
 new Car{ Name = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
 new Car{ Name = "Melvin", Color = "White", Speed = 43, Make = "Ford"},
};

GetFastCars(cars);
GetFastBMW(cars);
LINQOverLegacy();
OfTypeAsFilter();

static void GetFastCars(List<Car> cars)
{
    var fastCars = from c in cars where c.Speed > 55 select c;
    foreach (var car in fastCars) Console.WriteLine($"{car.Name} is fast");
    Console.WriteLine();
}

static void GetFastBMW(List<Car> cars)
{
    var fastCars = from c in cars where c.Speed > 90 && c.Make == "BMW" select c;
    foreach (var car in fastCars) Console.WriteLine($"{car.Name} is fast BMW");
    Console.WriteLine();
}

static void LINQOverLegacy()
{
    ArrayList cars = new()
    {
        new Car { Name = "Henry", Color = "Silver", Speed = 100, Make = "BMW" },
        new Car { Name = "Daisy", Color = "Tan", Speed = 90, Make = "BMW" },
        new Car { Name = "Mary", Color = "Black", Speed = 55, Make = "VW" },
        new Car { Name = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo" },
        new Car { Name = "Melvin", Color = "White", Speed = 43, Make = "Ford" },
    };
    // transform into IEnumerable
    var carsEnum = cars.OfType<Car>();
    var fastCars = from c in carsEnum where c.Speed >= 55 select c;
    foreach (var car in fastCars) Console.WriteLine($"{car.Name} is fast, speed: {car.Speed}");
    Console.WriteLine();
}

static void OfTypeAsFilter()
{
    ArrayList mesh = new();
    mesh.AddRange(new object[] { 10, 400, 8, false, new Car(), "string" });
    var ints = mesh.OfType<int>();
    foreach (int i in ints) Console.WriteLine(i);
    Console.WriteLine();
}
