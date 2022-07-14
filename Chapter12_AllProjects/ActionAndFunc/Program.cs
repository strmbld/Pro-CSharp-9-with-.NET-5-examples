using System;

// Action<> supports callbacks with up to 16 args and return void
// Func<> supports callbacks with up to 16(-1?) args and custom return value; last param is return type Func< , , , ret_type> 

Action<string, ConsoleColor, int> target = ShowMsg;
target("some message".ToUpper(), ConsoleColor.Green, 5);
Console.WriteLine();

Action<string, ConsoleColor, int> target2 = ShowMsg;
target2 += target;
target2("target 2", ConsoleColor.DarkCyan, 3);
Console.WriteLine();

Func<int, int, int> f1 = Add;
int res = f1(40, 40);
Console.WriteLine(res);
Console.WriteLine();

Func<int, int, string> f2 = SumToString;
Console.WriteLine(f2(25,35));

// callback
static void ShowMsg(string msg, ConsoleColor txtColor, int count)
{
    ConsoleColor previous = Console.ForegroundColor;
    Console.ForegroundColor = txtColor;
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine(msg);
    }
    Console.ForegroundColor = previous;
}

// another callback
static int Add(int x, int y) => x + y;
// one more
static string SumToString(int x, int y) => (x + y).ToString();

// public delegate void PseudoAction<T>(T arg);
