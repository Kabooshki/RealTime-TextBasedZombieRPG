public class Menu  {
    public static List<Option> menu_options;
    public Menu() {
        menu_options = new List<Option> 
        {
            new Option("Start Game", () => InstantiatePlayer()), 
            new Option("Load Game", () => WriteTemporaryMessage("No Saves Created Yet.")),
            new Option("Exit", () => Environment.Exit(0)),
        };

            int index = 0;

            WriteMenu(menu_options, menu_options[index]);

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < menu_options.Count)
                    {
                        index++;
                        WriteMenu(menu_options, menu_options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(menu_options, menu_options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    menu_options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();
    }

    static void WriteTemporaryMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(1200);
            WriteMenu(menu_options, menu_options.First());
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

    static void InstantiatePlayer() {
            Player player = new Player();
            WriteTemporaryMessage("Welcome To The Apocalypse!");
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
