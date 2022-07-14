using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ObservableCollections;

ObservableCollection<Person> ppl = new()
{
    new Person("Peter", 52),
    new Person("Kevin", 48),
};
ppl.CollectionChanged += ppl_CollectionChanged;

ppl.Add(new Person("Fred", 32));
ppl.RemoveAt(0);

static void ppl_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
{
    Console.WriteLine($"Action triggered event: {e.Action}");
    if (e.Action == NotifyCollectionChangedAction.Remove)
    {
        Console.WriteLine("Old items:");
        foreach (Person person in e.OldItems)
        {
            Console.WriteLine(person);
        }
        Console.WriteLine();
    }
    if (e.Action == NotifyCollectionChangedAction.Add)
    {
        Console.WriteLine("New items:");
        foreach (Person person in e.NewItems)
        {
            Console.WriteLine(person);
        }
    }
}

namespace ObservableCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
