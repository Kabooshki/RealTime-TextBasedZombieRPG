using System;
using System.Collections.Generic;

public class GameMenu
{
	public Player CurrentPlayer;
	public static List<Option> MenuOptions;
	public GameMenu(Player currentPlayer)
	{
		this.CurrentPlayer = currentPlayer;
		MenuOptions = new List<Option>
		{
			new Option("View Stats", () => CurrentPlayer.DisplayStats()),
			new Option("Return To Menu", () => { })
		};
	}

	public void Play()
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
}