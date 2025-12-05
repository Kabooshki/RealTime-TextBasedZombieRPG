using System;
using System.Collections.Generic;

public class CustomisationMenu
{
	public Player CurrentPlayer;
	public static List<Option> MenuOptions;
	public CustomisationMenu(Player currentPlayer)
	{
		this.CurrentPlayer = currentPlayer;
		MenuOptions = new List<Option>
		{
			new Option("Customise Character", () => ParseClothing(CurrentPlayer)),
			new Option("View Stats", () => CurrentPlayer.DisplayStats()),
			new Option("Return To Menu", () => { })
		};
	}

	public void Customise()
	{
		int index = 0;

		ConsoleKeyInfo keyInfo;
		bool running = true;

		while (running)
		{
			MainMenu.WriteMenu(MenuOptions, MenuOptions[index]);
			keyInfo = Console.ReadKey();

			switch (keyInfo.Key)
			{
				case ConsoleKey.DownArrow:
                    if (index + 1 < MenuOptions.Count)
                    {
                        index++;
                    }
                    break;
				case ConsoleKey.UpArrow:
                    if (index - 1 >= 0)
                    {
                        index--;
                    }
                    break;
				case ConsoleKey.Enter:
                    MenuOptions[index].Selected.Invoke();
					if (index == MenuOptions.Count - 1) running = false;
                    index = 0;
                    break;
			}
		}
	}

	static void ParseClothing(Player player)
	{	
	    Console.Clear();
	    List<string> playerInitClothing = new();
	    foreach (string clothing in Player.PlayerClothingOptions)
	    {
		playerInitClothing.Add(SetClothing(clothing));
	    }

	    Console.Clear();
	    player.CustomiseClothing(playerInitClothing);
	    player.DisplayClothing();

		
	}

	static string SetClothing(string clothingOption)
	{
		while (true)
		{
			Console.WriteLine($"Enter your Player's {clothingOption}: ");
			string clothing = Console.ReadLine();

			return clothing;
		}
	}


}
