using System;
using System.IO;

ShowDirInfo();
ShowJpgFiles();
ShowDrives();

static void ShowDirInfo()
{
    DirectoryInfo dir = new($@"C{Path.VolumeSeparatorChar}{Path.DirectorySeparatorChar}Windows");
    Console.WriteLine("*** Dir info ***");
    Console.WriteLine($"Fullname: {dir.FullName}");
    Console.WriteLine($"Name: {dir.Name}");
    Console.WriteLine($"Parent: {dir.Parent}");
    Console.WriteLine($"CreatedAt: {dir.CreationTime}");
    Console.WriteLine($"Attr: {dir.Attributes}");
    Console.WriteLine($"Root: {dir.Root}");
    Console.WriteLine("***************");
    Console.WriteLine();
}
static void ShowJpgFiles()
{
    DirectoryInfo dir = new($@"C{Path.VolumeSeparatorChar}{Path.DirectorySeparatorChar}Windows{Path.DirectorySeparatorChar}Web{Path.DirectorySeparatorChar}Wallpaper");
    FileInfo[] images = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
    Console.WriteLine($"Found {images.Length} images");
    foreach (FileInfo file in images)
    {
        Console.WriteLine("*******************");
        Console.WriteLine($"Filename: {file.Name}");
        Console.WriteLine($"File size: {file.Length}");
        Console.WriteLine($"CreatedAt: {file.CreationTime}");
        Console.WriteLine($"Attr: {file.Attributes}");
        Console.WriteLine("*******************");
    }
}
static void ShowDrives()
{
    string[] drives = Directory.GetLogicalDrives();
    Console.WriteLine("*** Drives: ***");
    foreach (var s in drives) Console.WriteLine($"--> {s}");
}