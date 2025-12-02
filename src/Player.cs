using System;
using System.Collections.Generic;

public class Player
{
    // public string Name { get; set; }
    public int Health;
    public int Stamina;
    public int Hunger;
    public int Thirst;
    public int Speed;
    public int Smell;
    public int Height;
    public int Weight;
    public int Strength;
    public int EyeSight;
    public static string[] StatTypes = { "Health", "Stamina", "Hunger", "Thirst", "Speed", "Smell" };
    public Dictionary<string, int> PlayerStats;
    
    public Player(List<int> stats)
    {
        PlayerStats = new Dictionary<string, int>();
        for (int i = 0; i < StatTypes.Length; i++)
        {
            PlayerStats.Add(StatTypes[i], stats[i]);
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
}
