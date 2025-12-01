using System;
using System.Threading;
using System.Collections.Generic;

public class Menu
{
    public static List<Option> menu_options;
    public Menu()
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
            Console.WriteLine("Enter your Player's Health (Maximum: 100)");
            int health = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Player's Stamina (Maximum 100)");
            int stamina = int.Parse(Console.ReadLine());

            Player player = new Player(health, stamina);
            WriteTemporaryMessage("Welcome To The Apocalypse!");
        }
        catch (FormatException e)
        {
            WriteTemporaryMessage("Invalid Data!");
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
