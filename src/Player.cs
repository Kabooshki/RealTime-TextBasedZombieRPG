using System;
using System.Collections.Generic;

public class Player
{
    public static string[] StatTypes = { "Health", "Stamina", "Hunger", "Thirst", "Speed", "Smell" };
    public static string[] PlayerClothingOptions = {"Head", "Face", "Neck", "Torso-Under", "Torso-Over", "Hands", "Back", "Waist", "Legs", "Feet"};
    public Dictionary<string, int> PlayerStats;
    public Dictionary<string, string> PlayerClothing;
    
    public Player(List<int> stats)
    {
        PlayerStats = new Dictionary<string, int>();
        for (int i = 0; i < StatTypes.Length; i++)
        {
            PlayerStats.Add(StatTypes[i], stats[i]);
        }
    }

    //public void SetStat(string chosenStat, int newValue)
    //{
    //    if (PlayerStats.ContainsKey(chosenStat))
    //    {
    //        PlayerStats[chosenStat] = newValue;
    //
    //    }
    //}

    public void CustomiseClothing(List<string> clothing)
    {
        PlayerClothing = new Dictionary<string, string>();
        for (int i = 0; i < PlayerClothingOptions.Length; i++)
        {
            PlayerClothing.Add(PlayerClothingOptions[i], clothing[i]);
        }
    }

    public void DisplayStats()
    {
        Console.WriteLine("Current Stats:\n\n");
        string[] columns = ["Stat", "Value"];
        string[][] playerStats = new string[StatTypes.Length][];
        int index = 0;
        foreach (KeyValuePair<string, int> stat in PlayerStats)
        {
            playerStats[index] = [stat.Key, Convert.ToString(stat.Value)];
            index++;
        }

        TextTable statTable = new TextTable(columns, playerStats);
        Console.ReadLine();
    }

    public void DisplayClothing()
    {
        Console.WriteLine("Current Customisations:\n\n");
        string[] columns = ["Body Part", "Clothing"];
        string[][] playerClothing = new string[PlayerClothingOptions.Length][];
        int index = 0;
        foreach (KeyValuePair<string, string> clothing in PlayerClothing)
        {
            playerClothing[index] = [clothing.Key, clothing.Value];
            index++;
        }
        
        TextTable statTable = new TextTable(columns, playerClothing);
        Console.ReadLine();

    }
}
