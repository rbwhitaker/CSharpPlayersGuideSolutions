using System;

// Represents a simple health potion that restores up to 10 HP.
public class HealthPotion : IItem
{
    public string Name => "HEALTH POTION";

    public void Use(Battle battle, Character user)
    {
        int amount = 10;
        user.HP += amount;
        Console.WriteLine($"{user.Name}'s HP was increased by {amount}."); // This is not quite right. If something was at 4/5 HP and used a potion, it would have recovered 1 HP, though this will say 10.
    }
}
