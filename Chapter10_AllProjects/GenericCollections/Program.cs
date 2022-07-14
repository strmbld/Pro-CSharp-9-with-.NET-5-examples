using System;
using System.Collections.Generic;
using GenericCollections;

UseGenericList();
UseGenericStack();
UseGenericQueue();
UseSortedSet();
UseDictionary();

static void UseDictionary()
{
    Dictionary<string, Person> d1 = new();
    d1.Add("Homer", new Person("Homer", 47));
    d1.Add("Marge", new Person("Marge", 45));
    d1.Add("Lisa", new Person("Lisa", 9));
    Person homer = d1["Homer"];
    Console.WriteLine(homer);
    Dictionary<string, Person> d2 = new()
    {
        { "Homer", new Person("Homer", 47) },
        { "Marge", new Person("Marge", 45) },
        { "Lisa", new Person("Lisa", 9) },
        //["Maggie"] = new Person("Maggie", 2),
    };
    Person lisa = d2["Lisa"];
    Console.WriteLine(lisa);
}

static void UseSortedSet()
{
    SortedSet<Person> set = new SortedSet<Person>(new SortByAge())
    {
        new Person("Homer", 47),
        new Person("Marge", 45),
        new Person("Lisa", 9),
        new Person("Bart", 8),
    };
    foreach (Person person in set)
    {
        Console.WriteLine(person);
    }
    Console.WriteLine();
    set.Add(new Person("Saku", 1));
    set.Add(new Person("Mikko", 32));
    foreach (Person person in set)
    {
        Console.WriteLine(person);
    }
    Console.WriteLine();
}

static void UseGenericQueue()
{
    // Make a Q with three people.
    Queue<Person> peopleQ = new();
    peopleQ.Enqueue(new Person { Name = "Homer", Age = 47 });
    peopleQ.Enqueue(new Person { Name = "Marge", Age = 45 });
    peopleQ.Enqueue(new Person { Name = "Lisa", Age = 9 });
    // Peek at first person in Q.
    Console.WriteLine("{0} is first in line!", peopleQ.Peek().Name);
    // Remove each person from Q.
    GetCoffee(peopleQ.Dequeue());
    Console.WriteLine("{0} is first in line!", peopleQ.Peek().Name);
    GetCoffee(peopleQ.Dequeue());
    Console.WriteLine("{0} is first in line!", peopleQ.Peek().Name);
    GetCoffee(peopleQ.Dequeue());
    // Try to de-Q again?
    try
    {
        GetCoffee(peopleQ.Dequeue());
    }
    catch (InvalidOperationException e)
    {
        Console.WriteLine("Error! {0}", e.Message);
    }
    Console.WriteLine();
    //Local helper function
    static void GetCoffee(Person p)
    {
        Console.WriteLine("{0} got coffee!", p.Name);
    }
}

static void UseGenericStack()
{
    Stack<Person> stack = new();
    stack.Push(new Person("Homer", 47));
    stack.Push(new Person("Marge", 45));
    stack.Push(new Person("Lisa", 9));

    Console.WriteLine($"First: {stack.Peek()}");
    Console.WriteLine($"Popped: {stack.Pop()}");
    Console.WriteLine($"First: {stack.Peek()}");
    Console.WriteLine($"Popped: {stack.Pop()}");
    Console.WriteLine($"First: {stack.Peek()}");
    Console.WriteLine($"Popped: {stack.Pop()}");

    try
    {
        Console.WriteLine($"First: {stack.Peek()}");
        Console.WriteLine($"Popped: {stack.Pop()}");
    }
    catch (InvalidOperationException e)
    {
        Console.WriteLine($"Error: {e.Message}");
    }
    Console.WriteLine();
}

static void UseGenericList()
{
    List<Person> list = new List<Person>()
    {
        new Person("Homer", 47),
        new Person("Marge", 45),
        new Person("Lisa", 9),
        new Person("Bart", 8),
    };

    Console.WriteLine($"Count: {list.Count}");
    foreach (Person p in list)
    {
        Console.WriteLine(p);
    }
    Console.WriteLine();
    Console.WriteLine("Inserting new person");
    list.Insert(2, new Person("Maggie", 2));
    Console.WriteLine($"Count: {list.Count}");
    foreach (Person p in list)
    {
        Console.WriteLine(p);
    }
    Console.WriteLine();
    Person[] arr = list.ToArray();
    foreach (Person person in arr)
    {
        Console.WriteLine($"Name: {person.Name}");
    }
    Console.WriteLine();
}
