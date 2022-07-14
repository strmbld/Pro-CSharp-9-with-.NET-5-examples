using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LinqOverArray
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryOverStrings();
            QueryOverStringExtensionMethods();
            QueryOverInts();
        }
        static string[] GetStringSubsetArray()
        {
            string[] colors = { "Ligth Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            var red = from c in colors where c.Contains("Red") select c;
            return red.ToArray();
        }
        static void QueryOverInts()
        {
            int[] n = { 10, 20, 30, 40, 1, 2, 3, 8 };
            /*
            IEnumerable<int> l10_subset =
                from i in n
                where i < 10
                select i; // WhereArrayIterator<T>
            foreach (int x in l10_subset) Console.WriteLine(x);*/
            var l10_subset = from i in n where i < 10 select i;
            foreach (var x in l10_subset)
            {
                Console.WriteLine(x);
            }

            ReflectOverQueryResults(l10_subset);
        }
        static void QueryOverStrings()
        {
            string[] s = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            IEnumerable<string> ws_subset = 
                from i in s
                where i.Contains(" ")
                orderby i
                select i; // OrderedEnumerable<TElement, TKey>

            ReflectOverQueryResults(ws_subset);

            foreach (string item in ws_subset) Console.WriteLine(item);
        }
        static void QueryOverStringExtensionMethods()
        {
            string[] s = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            IEnumerable<string> ws_subset =
                s
                .Where(i => i.Contains(" "))
                .OrderBy(i => i) // OrderedEnumerable<TElement, TKey>
                .Select(i => i); // SelectIPartitionIterator

            ReflectOverQueryResults(ws_subset);

            foreach (string item in ws_subset) Console.WriteLine(item);
        }
        static void ReflectOverQueryResults(object resultSet, string queryType = "Query Expressions")
        {
            Console.WriteLine($"***** Query info of {queryType}");
            Console.WriteLine($"resultSet type: {resultSet.GetType().Name}");
            Console.WriteLine($"resultSet source: {resultSet.GetType().Assembly.GetName().Name}");
            Console.WriteLine();
        }
    }
}
