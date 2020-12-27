using System;

/// <summary>
/// A type of action that performs one of the available attacks.
/// </summary>
public class AttackAction : IAction
{
    private static readonly Random _random = new Random();

    // The character performing the attack.
    private readonly Character _attacker;

    // The attack being performed in this action.
    private readonly IAttack _attack;

    // The target of the attack.
    private readonly Character _target;

    // Creates a new AttackAction, supplying it the attacker, the attack, and the target for reference when the
    // attack actually runs.
    public AttackAction(Character attacker, IAttack attack, Character target)
    {
        _attacker = attacker;
        _attack = attack;
        _target = target;
    }

    // Executes the attack in the context of the battle.
    public void Execute(Battle battle)
    {
        ColoredConsole.WriteLine($"{_attacker.Name} used {_attack.Name} on {_target.Name}.", ConsoleColor.Gray);

        // Ask the attack to generate the initial attack data.
        AttackData initialData = _attack.GenerateData();
        AttackData modifiedData = initialData;

        // Handle misses. (The way this is written does not allow modifiers to change the probability, which could have been nice.)
        if (_random.NextDouble() > modifiedData.Probability)
        {
            ColoredConsole.WriteLine($"{_attacker.Name} MISSED.", ConsoleColor.Magenta);
            return;
        }

        // Pass the attack data through both offensive and defensive attack modifiers to give them a chance to change the attack's properties.
        if (_attacker.OffensiveModifier != null) modifiedData = _attacker.OffensiveModifier.Modify(modifiedData, battle, _attacker, _target);
        if (_target .DefensiveModifier != null) modifiedData = _target.DefensiveModifier.Modify(modifiedData, battle, _attacker, _target);

        // Deal out the actual damage and report it.
        _target.HP -= modifiedData.Amount;
        Console.WriteLine($"{_attack.Name} dealt {modifiedData.Amount} {modifiedData.Type.ToString().ToUpper()} damage to {_target.Name}.");
        Console.WriteLine($"{_target.Name} is now at {_target.HP}/{_target.MaxHP} HP.");

        // If the target was killed in the attack, it should be removed from the game.
        if (!_target.IsAlive)
        {
            battle.GetPartyFor(_target).Characters.Remove(_target);
            Console.WriteLine($"{_target.Name} was defeated!");

            // The attacking party should immediately recover any item that the killed character had equipped.
            if (_target.EquippedItem != null)
            {
                ColoredConsole.WriteLine($"{_target.Name}'s {_target.EquippedItem.Name} was acquired by {_attacker.Name}'s party and is now in their shared inventory.", ConsoleColor.Magenta);
                battle.GetPartyFor(_attacker).SharedInventory.Equipment.Add(_target.EquippedItem);
                _target.EquippedItem = null;
            }
        }
    }
}
