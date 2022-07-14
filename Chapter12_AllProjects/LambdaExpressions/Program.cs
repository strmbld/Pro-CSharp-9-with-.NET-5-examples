using System;
using System.Collections.Generic;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            TraditionalDelegateSyntax();
            Console.WriteLine();
        }

        static void LambdaExpressionSyntax()
        {
            List<int> list = new();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            List<int> even = list.FindAll(i => (i % 2) == 0);
            Console.WriteLine("Even:");
            foreach (int e in even) Console.WriteLine(e);
        }
        static void AnonymousMethodSyntax()
        {
            List<int> list = new();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            List<int> even = list.FindAll(delegate (int i) { return (i % 2) == 0; });
            Console.WriteLine("Even:");
            foreach (int e in even) Console.WriteLine(e);
        }

        static void TraditionalDelegateSyntax()
        {
            List<int> list = new();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            Predicate<int> callback = IsEvenNumber;
            List<int> even = list.FindAll(callback);
            Console.WriteLine("Even:");
            foreach (int e in even) Console.WriteLine(e);
        }

        static bool IsEvenNumber(int i) => (i % 2) == 0;
    }
}
