using System;
using System.Linq;

class CustomLINQExtensionMethods
    {
    static void Main()
    {
        string[] games = {"Diablo", "Neverwinter Nights", "LoL", "Dexters", "Bejeweled"};
        
        //Extension method WhereNot
        var filteredGames = games.WhereNot(g => g.Length > 4).Select(g => g);

        foreach (var filteredGame in filteredGames)
        {
        Console.WriteLine(filteredGame);
        }

        //Extension method Repeat
        var repeatedGames = games.Repeat(3);

        foreach (var repeatedGame in repeatedGames)
        {
        Console.WriteLine(repeatedGame);
        }

        //Extension method WhereEndsWith
        string[] suffixes = {"d", "s"};

        var gamesEndsWith = games.WhereEndsWith<string>(suffixes);
        foreach (var game in gamesEndsWith)
            {
            Console.WriteLine(game);
            }
    }
    }