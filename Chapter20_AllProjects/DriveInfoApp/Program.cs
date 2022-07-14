using System;
using System.IO;

DriveInfo[] drives = DriveInfo.GetDrives();
foreach (var d in drives)
{
    Console.WriteLine($"Name: {d.Name}");
    Console.WriteLine($"Type: {d.DriveType}");
    if (d.IsReady)
    {
        Console.WriteLine($"Total size: {d.TotalSize}");
        Console.WriteLine($"Free space: {d.TotalFreeSpace}");
        Console.WriteLine($"Format: {d.DriveFormat}");
        Console.WriteLine($"Label: {d.VolumeLabel}");
        Console.WriteLine();
    }
    Console.WriteLine();
}