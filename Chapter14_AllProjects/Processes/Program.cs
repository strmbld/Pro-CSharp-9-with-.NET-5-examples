using System;
using System.Diagnostics;
using System.Linq;

namespace Processes
{
    class Program
    {
        static void Main(string[] args)
        {
            ListAllProcesses();
            Console.Write("PID:");
            int pID = int.Parse(Console.ReadLine());
            EnumThreadsForPid(pID);
            Console.WriteLine();
            EnumModulesForPid(pID);
            Console.WriteLine();
            StartAndKillProcess();
        }

        static void ListAllProcesses()
        {
            var procs = from proc in Process.GetProcesses(".") orderby proc.Id select proc;
            int count = procs.Count();
            foreach (var p in procs)
            {
                Console.WriteLine($"-> PID: {p.Id}\tName: {p.ProcessName}");
            }
            Console.WriteLine($"Total count: {count} *****************");
        }
        static void EnumThreadsForPid(int pID)
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(pID);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"Process name: {proc.ProcessName}");
            Console.WriteLine($"Process threads:");
            ProcessThreadCollection threads = proc.Threads;
            foreach (ProcessThread processThread in threads)
            {
                Console.WriteLine($"-> Thread ID: {processThread.Id}\tStart time: {processThread.StartTime.ToShortTimeString()}\tPriority: {processThread.PriorityLevel}");
            }
            Console.WriteLine();
        }
        static void EnumModulesForPid(int pID)
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(pID);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"Process name: {proc.ProcessName}");
            ProcessModuleCollection modules = proc.Modules;
            foreach (ProcessModule processModule in modules)
            {
                Console.WriteLine($"-> Module name: {processModule.ModuleName}");
            }
            Console.WriteLine();
        }
        static void StartAndKillProcess()
        {
            Process proc = null;
            try
            {
                proc = Process.Start(@"C:\Windows\notepad.exe");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"press any key to kill process {proc.ProcessName}");
            Console.ReadKey();
            try
            {
                foreach (var p in Process.GetProcessesByName("notepad"))
                {
                    p.Kill(true);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
