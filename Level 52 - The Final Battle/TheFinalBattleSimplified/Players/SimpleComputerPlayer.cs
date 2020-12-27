using System;
using System.Linq;
using System.Threading;

public class SimpleComputerPlayer : IPlayer
{
    private static readonly Random _random = new Random();

    public IAction PickAction(Battle battle, Character character)
    {
        Console.WriteLine($"{character.Name} is taking a turn...");
        Thread.Sleep(50);
        Party enemies = battle.GetOpposingParty(character);

        // If there is a potion available, the character's health is under 50%, then 25% of the time, use a potion.
        HealthPotion potion = battle.GetPartyFor(character).SharedInventory.Items.OfType<HealthPotion>().FirstOrDefault();
        if (potion != null && character.HP / (float)character.MaxHP < 0.5f)
            if (_random.NextDouble() < 0.25f)
                return new UseItemAction(character, potion);

        if(character.Ability != null)
            return new UseAbilityAction(character, character.Ability);

        if (enemies.Characters.Count > 0)
        {
            if (character.EquippedItem != null) return new AttackAction(character, character.EquippedItem.Attack, enemies.Characters[_random.Next(enemies.Characters.Count)]);
            else return new AttackAction(character, character.Attack, enemies.Characters[_random.Next(enemies.Characters.Count)]);
        }

        else return new DoNothingAction(character);
    }
}