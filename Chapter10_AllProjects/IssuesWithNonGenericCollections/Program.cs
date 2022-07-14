using System;
using System.Collections.Generic;
using IssuesWithNonGenericCollections;

List<Person> persons = new();
persons.Add(new Person("Frank", 50));
Console.WriteLine(persons[0]);

List<int> ints = new();
ints.Add(10);
ints.Add(2);
int sum = ints[0] + ints[1];
Console.WriteLine(sum);



static void SimpleBoxOperation()
{
    int i = 25;
    object boxed_i = i;
    int unboxed_i = (int)boxed_i;
}

namespace IssuesWithNonGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
