using System.Collections.Generic;

public class GameMenu
{
	public Player CurrentPlayer;
	public static List<Option> menu_options;
	public GameMenu(Player currentPlayer)
	{
		this.CurrentPlayer = currentPlayer;
		menu_options = new List<Option>
		{

		};
	}

	public static void Play()
	{

	}
}