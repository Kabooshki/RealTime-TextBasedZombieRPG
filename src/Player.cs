using System.Collections.Generic;

public class Player
{
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
    public static string[] StatTypes = { "" };
    public Dictionary<string, int> PlayerStats = new Dictionary<string, int>();
    
    public Player(List<int> stats)
    {
        for (int i = 0; i < StatTypes.Length; i++)
        {
            PlayerStats.Add(StatTypes[i], stats[i]);
        }
    }
}
