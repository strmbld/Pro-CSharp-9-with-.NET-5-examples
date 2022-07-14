using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

CancellationTokenSource cancelToken = new();

do
{
    Console.WriteLine("press anykey to start");
    Console.ReadKey();
    Console.WriteLine("Processing..");
    Task.Factory.StartNew(ProcessInts);
    Console.WriteLine("Type Q to quit:");
    string input = Console.ReadLine();
    if (input.Equals("Q", StringComparison.OrdinalIgnoreCase))
    {
        cancelToken.Cancel();
        break;
    }
} while (true);
Console.ReadKey();


void ProcessInts()
{
    int[] ints = Enumerable.Range(1, 500_000_000).ToArray();
    int[] mod3isZero = null;
    try
    {
        mod3isZero = (
        from i in ints.AsParallel().WithCancellation(cancelToken.Token)
        where i % 3 == 0
        orderby i descending
        select i
        ).ToArray();
        Console.WriteLine();
        Console.WriteLine($"Found {mod3isZero.Count()} query matches");
        Console.WriteLine();
    }
    catch (OperationCanceledException e)
    {
        Console.WriteLine(e.Message);
    }
}
