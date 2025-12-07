using System;
using System.Collections.Generic;
using System.Collections.Specialized;

public class TempMenu
{
	public static List<Option> menu_options;
	public TempMenu(Player currentPlayer)
	{
	    menu_options = new List<Option>
            {
                new Option("View Clothing", () => currentPlayer.DisplayClothing()),
                new Option("View Stats", () => currentPlayer.DisplayStats()),
                new Option("Return to Main Menu", () => { }),
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

}
