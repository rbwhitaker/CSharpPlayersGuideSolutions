/// <summary>
/// An action type that executes an attack on a target.
/// </summary>
public class AttackAction : IAction
{
    // The attack to run.
    private readonly IAttack _attack;

    // The target of the attack.
    private readonly Character _target;

    /// <summary>
    /// Creates a new attack action, capturing the attack and target of the attack.
    /// </summary>
    public AttackAction(IAttack attack, Character target)
    {
        _attack = attack;
        _target = target;
    }

    /// <summary>
    /// Runs the attack action.
    /// </summary>
    public void Run(Battle battle, Character character)
    {
        // Display that the attack is happening.
        Console.WriteLine($"{character.Name} used {_attack.Name} on {_target.Name}.");

        // Get the attack's damage for this specific attack and deal it out to the target.
        AttackData data = _attack.Create();
        _target.HP -= data.Damage;

        // Display that the damage has been dealt and where the character's HP is at now.
        Console.WriteLine($"{_attack.Name} dealt {data.Damage} damage to {_target.Name}.");
        Console.WriteLine($"{_target.Name} is now at {_target.HP}/{_target.MaxHP} HP.");

        // If the target dies because of the attack, remove it from the party and tell the user.
        if (!_target.IsAlive)
        {
            battle.GetPartyFor(_target).Characters.Remove(_target);
            Console.WriteLine($"{_target.Name} was defeated!");
            if(_target.EquippedGear != null)
            {
                IGear acquiredGear = _target.EquippedGear;
                battle.GetPartyFor(character).Gear.Add(acquiredGear);
                ColoredConsole.WriteLine($"{character.Name}'s party has recovered {_target.Name}'s {acquiredGear.Name}.", ConsoleColor.Magenta);
            }
        }
    }
}
