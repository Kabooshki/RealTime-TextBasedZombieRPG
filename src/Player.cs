public class Player 
{
    public int health;
    public int stamina;
    public int hunger;
    public int thirst;
    public int speed;
    public int smell;
    public int height;
    public int weight;
    public int strength;
    public int eye_sight;
    
    public Player() 
    {
        Console.WriteLine("Enter your Player's Health (Maximum: 100)");
        health = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter your Player's Stamina (Maximum 100)");
        stamina = Convert.ToInt32(Console.ReadLine());

    }
}
