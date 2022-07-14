using System;
using CarDelegate;

Car c1 = new("SlugBug", 100, 10);
Car.CarEngineHandler handler1 = new(OnCarEngineEvent);
c1.RegisterCallback(handler1);
Car.CarEngineHandler handler2 = new(OnCarEngineEvent2);
c1.RegisterCallback(handler2);

for (int i = 0; i < 6; i++)
{
    c1.Accelerate(20);
}

c1.UnregisterCallback(handler2);

for (int i = 0; i < 6; i++)
{
    c1.Accelerate(20);
}
Console.WriteLine();

Console.WriteLine("*** BMW ***");
Car c2 = new("BMW", 150, 20);
c2.RegisterCallback(OnCarEngineEvent);

for (int i = 0; i < 6; i++)
{
    c2.Accelerate(20);
}

ExampleGenericDelegate<string> target = new(Target);
// target = (ExampleGenericDelegate<string>)Delegate.Combine(target, new ExampleGenericDelegate<string>(OnCarEngineEvent));
// target += new ExampleGenericDelegate<string>(OnCarEngineEvent);
target("something");
// Console.WriteLine(target.GetInvocationList().Length);
ExampleGenericDelegate<int> targetInt = new(TargetInt);
targetInt(5+25);

static void OnCarEngineEvent(string msg)
{
    Console.WriteLine("*** msg from car obj ***");
    Console.WriteLine(msg);
    Console.WriteLine("************************");
}
static void OnCarEngineEvent2(string m) => Console.WriteLine(m.ToUpper());

static void Target(string arg) => Console.WriteLine($"arg: {arg.ToUpper()}");
static void TargetInt(int arg) => Console.WriteLine($"arg: {arg}");

public delegate void ExampleGenericDelegate<T>(T arg);