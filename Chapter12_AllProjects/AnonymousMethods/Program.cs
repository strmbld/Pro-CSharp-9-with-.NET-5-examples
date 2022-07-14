using System;
using AnonymousMethods;

Car c1 = new("SlugBug", 100, 10);
int count = 0;
c1.AboutToBlow += delegate { Console.WriteLine("going too fast"); };
c1.AboutToBlow += static delegate (object sender, CarEventArgs e)
{
    // count++;
    Console.WriteLine($"Message from {sender}: {e.message}");
};
c1.Exploded += delegate (object sender, CarEventArgs e)
{
    global::System.Console.WriteLine($"Fatal: {e.message}");
};

for (int i = 0; i < 6; i++)
{
    c1.Accelerate(20);
}
Console.WriteLine();


