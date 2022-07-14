using System;
using CarLibrary;

namespace CSharpCarClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SportsCar viper = new("Viper", 240, 40);
            viper.TurboBoost();
            MiniVan mv = new();
            mv.TurboBoost();
        }
    }
}
