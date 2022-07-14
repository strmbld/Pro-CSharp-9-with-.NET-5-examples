using System;
using Shapes;
using bfHome = System.Runtime.Serialization.Formatters.Binary;

namespace CustomNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Hexagon h = new();
            Circle c = new();
            Square s = new();
            bfHome.BinaryFormatter b = new();
        }
    }
}
