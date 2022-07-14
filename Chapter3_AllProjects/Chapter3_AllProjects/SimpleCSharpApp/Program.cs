using System;
//using SimpleCSharpApp;
// namespace SimpleCSharpApp
// {
// class Program
// {
// static void Main(string[] args)
// {
Console.WriteLine("hello there**********");
            Console.WriteLine("yeah app");
            Console.WriteLine();

            string s = Console.ReadLine();

            Console.WriteLine(s);

            Console.ReadKey();


PP pp = new PP();
pp.Hello();
int x = pp.GetHashCode();
Console.WriteLine("hash: " + x);
string[] args1 = Environment.GetCommandLineArgs();
foreach (string arg in args1) Console.WriteLine(arg);

ShowEnvDetails();

Console.ReadKey();

static void ShowEnvDetails()
{
    foreach (string drive in Environment.GetLogicalDrives()) Console.WriteLine("Drive: {0}", drive);
    Console.WriteLine("OS: {0}", Environment.OSVersion);
    Console.Write("1");Console.Write("2");Console.Write("3");
    Console.WriteLine("Number of CPUs: {0}", Environment.ProcessorCount);
    Console.WriteLine(".NET version: {0}", Environment.Version);
    Console.WriteLine("ExitCode: {0}", Environment.ExitCode);
    Console.WriteLine("is64: {0}", Environment.Is64BitOperatingSystem);
    Console.WriteLine("MachineName: {0}", Environment.MachineName);
    Console.WriteLine("nl: {0}", Environment.NewLine);
    Console.WriteLine("SystemDir: {0}", Environment.SystemDirectory);
    Console.WriteLine("SystemPageSize: {0}", Environment.SystemPageSize);
    Console.WriteLine("UserName: {0}", Environment.UserName);
}
    class PP
    {
        public void Hello()
        {
            Console.WriteLine("hhhhhhh");
        }
    }



    

  // }
  // }
  // }
