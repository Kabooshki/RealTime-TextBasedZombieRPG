using System;
using System.Collections.Generic;
using System.Linq;

public class CustomisationMenu
{
	public Player CurrentPlayer;
	public static List<Option> MenuOptions;
	public CustomisationMenu(Player currentPlayer)
	{
		this.CurrentPlayer = currentPlayer;
		MenuOptions = new List<Option>
		{
			new Option("Customise Character", () => ParseClothing(currentPlayer)),
			new Option("View Stats", () => currentPlayer.DisplayStats()),
			new Option("Return To Menu Menu", () => { })
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
	    Dictionary<string, string> set_clothing = SetClothing();
	    List<string> playerInitClothing = new();
	    foreach (KeyValuePair<string, string> clothing in set_clothing)
	    {
		playerInitClothing.Add(clothing.Value);
	    }

	    Console.Clear();
	    player.CustomiseClothing(playerInitClothing);
	    player.DisplayClothing();
	    TempMenu temp = new TempMenu(player);
	}

	static Dictionary<string, string> SetClothing()
	{
		Dictionary<string, string[]> clothing = new Dictionary<string, string[]>();
		clothing.Add("Head", ["Baseball Cap", "Beanie", "Motorcycle Helmet", "None"]);
		clothing.Add("Face", ["Glasses", "Mouth-Guard", "None"]);
		clothing.Add("Neck", ["Scarf", "Necklace", "None"]);
		clothing.Add("Torso-Under", ["T-shirt", "Vest", "Hoodie", "None"]);
		clothing.Add("Torso-Over", ["Coat", "Leather-Vest", "Hoodie", "None"]);
		clothing.Add("Hands", ["Wedding Ring", "Gloves", "None"]);
		clothing.Add("Back", ["Backpack", "Guitar", "Sports Bag", "None"]);
		clothing.Add("Waist", ["Belt", "Fanny-pack", "Gun Holster", "None"]);
		clothing.Add("Legs", ["Jeans", "Shorts", "Skirt", "None"]);
		clothing.Add("Feet", ["Trainers", "Sandals", "Socks", "None"]);

		Dictionary<string, int> selectedIndices = new Dictionary<string, int>();
		foreach (var key in clothing.Keys)
		{
			selectedIndices[key] = 0;
		}

		ConsoleKeyInfo keyPressed;
		int bodyPartIndex = 0;
		bool running = true;

		while (running)
		{
			DisplayClothingMenu(clothing, selectedIndices, bodyPartIndex);
			keyPressed = Console.ReadKey();

			string currentBodyPart = Player.PlayerClothingOptions[bodyPartIndex];

			switch (keyPressed.Key)
			{
				case ConsoleKey.UpArrow:
					if (bodyPartIndex - 1 >= 0)
					{
						bodyPartIndex--;
					}
						break;

				case ConsoleKey.DownArrow:
					if (bodyPartIndex + 1 < clothing.Count)
					{
						bodyPartIndex++;
					}
					break;

				case ConsoleKey.LeftArrow:
					if (selectedIndices[currentBodyPart] - 1 >= 0)
					{
						selectedIndices[currentBodyPart]--;
					}
					break;

				case ConsoleKey.RightArrow:
					if (selectedIndices[currentBodyPart] + 1 < clothing[currentBodyPart].Length)
					{
						selectedIndices[currentBodyPart]++;
					}
					break;

				case ConsoleKey.Enter:
					running = false;
					break;
			}

		}
		
		Dictionary<string, string> result = new Dictionary<string, string>();
		foreach (var bodyPart in Player.PlayerClothingOptions)
		{
			result[bodyPart] = clothing[bodyPart][selectedIndices[bodyPart]];
		}

		return result;
	}


	static void DisplayClothingMenu(Dictionary<string, string[]> clothing, Dictionary<string, int> selectedIndices, int currentIndex)
		{
			Console.Clear();
			Console.WriteLine("Select Your Clothing:\n");

			for (int i = 0; i < Player.PlayerClothingOptions.Length; i++)
			{
				string bodyPart = Player.PlayerClothingOptions[i];
				int selectedItemIndex = selectedIndices[bodyPart];
				string selectedItem = clothing[bodyPart][selectedItemIndex];

				if (i == currentIndex)
				{
					Console.Write("-> ");
				}
				else
				{
					Console.Write("   ");
				}

				Console.WriteLine($"{bodyPart,-15}: {selectedItem,-20} (<- ->: Change)");
			}

			Console.WriteLine("\n ↑ ↓: Navigate | <- ->: Cycle Items | Enter: Confirm");
		}

}
