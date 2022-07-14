using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Text;

string book = "";
GetBook();
Console.WriteLine("Downloading...");
Console.ReadKey();

void GetBook()
{
    WebClient client = new();
    client.DownloadStringCompleted += (s, eventArgs) =>
    {
        book = eventArgs.Result;
        Console.WriteLine("Download completed");
        GetStats();
    };

    client.DownloadStringAsync(new Uri("https://www.gutenberg.org/files/98/old/98-8.txt"));
}
void GetStats()
{
    string[] words = book.Split(new char[]
        {' ', '\u000A', ',', '.', ';', ':', '-', '?', '/'},
        StringSplitOptions.RemoveEmptyEntries);

    string[] tmc = null; // FindTenMostCommon(words);
    string lw = string.Empty; // FindLongestWord(words);

    Parallel.Invoke(
        () => { tmc = FindTenMostCommon(words); },
        () => { lw = FindLongestWord(words); }
        );

    StringBuilder stats = new("Ten most common words:\n");
    foreach (string s in tmc)
    {
        stats.AppendLine(s);
    }
    stats.AppendFormat($"Longest word: {lw}");
    stats.AppendLine();
    Console.WriteLine(stats.ToString(), "Book info");
}
string[] FindTenMostCommon(string[] words)
{
    var freq = from word in words
               where word.Length > 6
               group word by word into g
               orderby g.Count() descending
               select g.Key
               ;
    return (freq.Take(10)).ToArray();
}
string FindLongestWord(string[] words) =>
    (from w in words orderby w.Length descending select w).FirstOrDefault();