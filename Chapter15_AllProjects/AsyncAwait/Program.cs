using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

string s = await DoWorkAsync();
Console.WriteLine(s);
Console.WriteLine("Completed");
Console.ReadKey();

static string DoWork()
{
    Thread.Sleep(5000);
    return "Done";
}
static async Task<string> DoWorkAsync()
{
    return await Task.Run(() =>
    {
        Thread.Sleep(5000);
        return "Done";
    });
}
