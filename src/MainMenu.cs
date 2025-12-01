using System;
using System.Threading;
using System.Collections.Generic;

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

    static void WriteMenu(List<Option> options, Option selectedOption)
    {
        Console.Clear();

        foreach (Option option in menu_options)
        {
            if (option == selectedOption)
            {
                Console.Write("->");
            }
            else
            {
                Console.Write(" ");
            }

            Console.WriteLine(option.Name);
        }
    }

    static void InstantiatePlayer()
    {
        try
        {
            //Console.WriteLine("Enter your Player's Health (Maximum: 100)");
            //int health = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter your Player's Stamina (Maximum 100)");
            //int stamina = int.Parse(Console.ReadLine());

            //Player player = new Player(health, stamina);
            //WriteTemporaryMessage("Welcome To The Apocalypse!");
            Console.Clear();
            string[] columns = ["Stat", "Value"]; 
            string[][] player_stats = new string[6][];
            player_stats[0] = new string[] {"Health", "100"};
            player_stats[1] = new string[] {"Stamina", "100"};
            player_stats[2] = new string[] {"Hunger", "150"};
            player_stats[3]= new string[] {"Thirst", "150"};
            player_stats[4] = new string[] {"Speed", "1.2"};
            player_stats[5] = new string[] {"Smell", "0"};
            TextTable stat_table = new TextTable(columns, player_stats);
            Console.ReadLine();
        }
        catch (FormatException e)
        {
            WriteTemporaryMessage("Invalid Data!");
        }
    }

    static int SetStat(string statType, int limit)
    {
        while (true)
        {
            try
            {
                Console.WriteLine($"Enter your Player's {statType} (Maximum: {limit})");
                int stat = int.Parse(Console.ReadLine());

                if (stat >= 0 && stat <= limit) return stat;
                else Console.WriteLine($"{statType} must be above 0 and below {limit}!");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid value.");
            }
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
