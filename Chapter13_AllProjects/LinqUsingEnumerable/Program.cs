using System;
using System.Linq;

static void QueryStringWOperators()
{
    string[] games = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};
    var subset = from game in games where game.Contains(" ") orderby game select game;
}
static void QueryStringWEnumerable()
{
    string[] games = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
    var subset = games
        .Where(game => game.Contains(" ")) // System.Func<T1, TResult>; Func<IEnumerable<T>, bool>
        .OrderBy(game => game)
        .Select(game => game)
        ;
}
static void QueryStringsWithEnumerableBreakdown()
{
    string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};
    var gamesWithSpaces = currentVideoGames.Where(game => game.Contains(" "));
    var orderedGames = gamesWithSpaces.OrderBy(game => game);
    var subset = orderedGames.Select(game => game);
}
static void QueryStringsWithDelegates()
{
    string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

    Func<string, bool> searchFilter = delegate (string game) { return game.Contains(" "); };
    Func<string, string> item = delegate (string s) { return s; };

    var subset = currentVideoGames
        .Where(searchFilter)
        .OrderBy(item)
        .Select(item)
        ;
}

class VeryComplexQueryExpr
{
    public static void QueryStringsWithDelegates()
    {
        string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

        Func<string, bool> searchFilter = new(Filter);
        Func<string, string> item = new(ProcessItem);

        var subset = currentVideoGames
            .Where(searchFilter)
            .OrderBy(item)
            .Select(item)
            ;
    }
    private static bool Filter(string game) => game.Contains(" ");
    private static string ProcessItem(string game) => game; 
}