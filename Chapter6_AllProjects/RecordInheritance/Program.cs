using System;

namespace RecordInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MiniVan m = new("Honda", "huiznaet", "cherry", 5);
            Console.WriteLine($"{m.Make},{m.Model},{m.Color},{m.Seating}");


            PositionalCar pc = new("wtf", "idk", "white");
            Console.WriteLine(pc);
            PositionalMiniVan pm = new("k", "ok", "red");
            Console.WriteLine(pm);
            Console.WriteLine($"{pm is PositionalCar}");
            TestIntRec tir = new(228);
            Console.WriteLine(tir);
            Console.WriteLine(tir.TestIR);
            // tir.TestIR = 444;
            TestStringRec tsr = new("test");
            Console.WriteLine(tsr);
            Console.WriteLine(tsr.TestSR);
            // tsr.TestSR = "new strnig";
        }

        
    }
    public record TestIntRec(int TestIR);
    public record TestStringRec(string TestSR);
    public record PositionalCar(string Make, string Model, string Color);
    public record PositionalMiniVan(string Make, string Model, string Color) : PositionalCar(Make,Model,Color);
}
