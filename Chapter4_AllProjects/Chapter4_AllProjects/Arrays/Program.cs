using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Arrays *****");
            Console.WriteLine("- set of data items of same type");

            SimpleArrays();
            ImplicitArraysDeclaration();
            ArrayOfObject();
            RectangularArray();
            JaggedMDArray();
            IndexAndRange();
        }

        static int Add(int x, int y) => x + y;
        static void IndexAndRange()
        {
            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 11, 12, 22, 33, 44, 56, 78, 65 };
            for (int i = 1; i <= ints.Length; i++)
            {
                Index idx = ^i;
                Console.WriteLine($"INTS: {ints[idx]}; INDEX idx: {idx}");
            }
            foreach (var item in ints[0..2])
            {
                Console.WriteLine(item+ ", ");
            }
            Console.WriteLine("RANGE*****************");
            Range r = ..7; // equals r = 0..7; can omit end index like 5.. so will traverse till [length-1]
                           // just .. means 'foreach' aswell as [0..^0]      (begin is inclusive, end is EXCLUSIVE)
            foreach (var item in ints[r])
            {
                Console.WriteLine(item+",");
            }
            Console.WriteLine();

        }
        static void JaggedMDArray()
        {
            Console.WriteLine("Jagged md array*******");

            int[][] jagged = new int[5][];
            for (int i = 0; i < 5; i++)
            {
                jagged[i] = new int[i + 7];
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void RectangularArray()
        {
            Console.WriteLine("Rectangular array************");

            int[,] matrix = new int[3, 4];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix[i, j] = i * j;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matrix[i,j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void ArrayOfObject()
        {
            Console.WriteLine("Array of object type");

            object[] objects = new object[4];
            objects[0] = 10;
            objects[1] = false;
            objects[2] = new DateTime(1969, 3, 24);
            objects[3] = "something";
            foreach (var obj in objects)
            {
                Console.WriteLine($"Type: {obj.GetType().FullName}, Value: {obj}");
            }
            Console.WriteLine();
        }

        static void ImplicitArraysDeclaration()
        {
            Console.WriteLine("*** Implicit array declaration");

            var integers = new[] { 1, 10, 100, 1000 };
            Console.WriteLine($"integers is: {integers}");

            var doubles = new[] { 1, 1.5, 2, 2.5 };
            Console.WriteLine($"doubles is: {doubles}");

            var strings = new[] { "hi", null, "there" };
            Console.WriteLine($"strings is: {strings}");
            foreach (var s in strings)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }

        static void SimpleArrays()
        {
            Console.WriteLine("*** Create ***");

            int[] ints = new int[5];
            ints[0] = 100;
            ints[1] = 200;
            ints[2] = 300;
            foreach (var i in ints)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            string[] string3 = new string[] { "one", "two", "three" };
            bool[] bools = { false, false, true };
            int[] ints1 = new int[4] { 20, 22, 23, 0 };

            string[] strings = new string[100];
            Console.WriteLine();
        }
    }
}
