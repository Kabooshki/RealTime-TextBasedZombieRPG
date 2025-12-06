using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Specialized;

public class MainMenu
{
    public static List<Option> menu_options;
    public MainMenu()
    {
        menu_options = new List<Option>
        {
            new Option("Start Game", () => InstantiatePlayer()),
            new Option("Load Game", () => WriteTemporaryMessage("No Saves Created Yet.")),
            new Option("Exit", () => Environment.Exit(0)),
        };

        int index = 0;
        ConsoleKeyInfo keyinfo;

        do
        {
            WriteMenu(menu_options, menu_options[index]);

            keyinfo = Console.ReadKey();

            if (keyinfo.Key == ConsoleKey.DownArrow)
            {
                if (index + 1 < menu_options.Count)
                {
                    index++;
                }
            }
            if (keyinfo.Key == ConsoleKey.UpArrow)
            {
                if (index - 1 >= 0)
                {
                    index--;
                }
            }
            if (keyinfo.Key == ConsoleKey.Enter)
            {
                menu_options[index].Selected.Invoke();
                index = 0;
            }
        }
        while (keyinfo.Key != ConsoleKey.X);
    }

    static void WriteTemporaryMessage(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Thread.Sleep(1200);
    }

    public static void WriteMenu(List<Option> options, Option selectedOption)
    {
        Console.Clear();

        foreach (Option option in options)
        {
            if (option == selectedOption)
            {
                Console.Write("->");
            }
            else
            {
                Console.Write("  ");
            }

            Console.WriteLine(option.Name);
        }
    }

    public static void WriteStatMenu(Dictionary<string, int[]> stats, string selectedOption, int sparePoints)
    {
        Console.Clear();

        foreach (var option in stats)
        {
            if (selectedOption == option.Key)
            {
                Console.Write("->");
            }
            else
            {
                Console.Write("  ");
            }

            Console.WriteLine($"{option.Key,-15}:  {option.Value[0]}");
        }

        Console.WriteLine($"\nRemaining Points => {sparePoints}");
    }

    static void InstantiatePlayer()
    {
        try
        {
            Console.Clear();

            Dictionary<string, int[]> stats = SetStats();

            // "Health", "Stamina", "Hunger", "Thirst", "Speed", "Smell"
            List<int> playerInitStats = new();

            foreach (KeyValuePair<string, int[]> stat in stats)
            {
                playerInitStats.Add(stat.Value[0]);
            }

            Console.Clear();
            Player player = new Player(playerInitStats);
            player.DisplayStats();

            GameMenu game = new GameMenu(player);
            game.Play();
        }
        catch (FormatException e)
        {
            WriteTemporaryMessage("Invalid Data!");
        }
    }

    private static Dictionary<string, int[]> SetStats()
    {
        // Key -> stat type
        // Value[0] -> Base points
        // Value[1] -> Min points
        // Value[2] -> Max points
        Dictionary<string, int[]> stats = new Dictionary<string, int[]>();
        stats.Add("Health", [50, 30, 100]);
        stats.Add("Stamina", [50, 30, 100]);
        stats.Add("Hunger", [20, 10, 40]);
        stats.Add("Thirst", [20, 10, 40]);
        stats.Add("Speed", [24, 10, 50]);
        stats.Add("Smell", [5, 3, 20]);

        int sparePoints = 25;

        ConsoleKeyInfo keyInfo;
        int index = 0;
        bool running = true;

        while (running)
        {
            WriteStatMenu(stats, Player.StatTypes[index], sparePoints);

            keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (index - 1 >= 0)
                    {
                        index--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (index + 1 < stats.Count)
                    {
                        index++;
                    }
                    break;

                // Decrease Stat
                case ConsoleKey.LeftArrow:
                    if (stats[Player.StatTypes[index]][0] > stats[Player.StatTypes[index]][1])
                    {
                        stats[Player.StatTypes[index]][0]--;
                        sparePoints++;
                    }
                    break;

                // Increase Stat
                case ConsoleKey.RightArrow:
                    if (sparePoints > 0 && stats[Player.StatTypes[index]][0] < stats[Player.StatTypes[index]][2])
                    {
                        stats[Player.StatTypes[index]][0]++;
                        sparePoints--;
                    }
                    break;

                case ConsoleKey.Enter:
                    running = false;
                    break;
            }
        }

        return stats;
    }

    // Stub
    private bool FinishPlayerCreation()
    {
        while (true)
        {
            return true;
        }
    }
}

public class Option {
    public string Name { get; }
    public Action Selected { get; }

    public Option(string name, Action selected) {
        Name = name;
        Selected = selected;
    }
}
