using System;

namespace SimpleFinalize
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateObjects(1000000);
            GC.AddMemoryPressure(2147483647);
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            
        }

        static void CreateObjects(int n)
        {
            ResourceWrapper[] trash = new ResourceWrapper[n];
            for (int i = 0; i < n; i++)
            {
                trash[i] = new ResourceWrapper();
            }
        }
    }
}
