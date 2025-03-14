/// <summary>
/// The main hero and player character of the game.
/// </summary>
public class TheTrueProgrammer : Character
{
    public override string Name { get; }

    public TheTrueProgrammer(string name) : base(25)
    {
        Name = name;
        EquippedGear = new Sword();
        DefensiveModifier = new ObjectSight();
    }

    public override IAttack StandardAttack { get; } = new Punch();
}

public class ObjectSight : IAttackModifier
{
    public string Name => "OBJECT SIGHT";

    public AttackData Modify(AttackData input)
    {
        if (input.Type != DamageType.Decoding) return input;

        ColoredConsole.WriteLine($"{Name} reduced the attack by 2 points.", ConsoleColor.Yellow);
        return input with { Damage = Math.Max(0, input.Damage - 2) };
    }
}

public class Sword : IGear
{
    public string Name => "SWORD";

    public IAttack Attack { get; } = new Slash();
}

public class Slash : IAttack
{
    public string Name => "SLASH";
    public AttackData Create() => new AttackData(2);
}

/// <summary>
/// Punch is a simple attack that reliably deals 1 damage.
/// </summary>
public class Punch : IAttack
{
    public string Name => "PUNCH";
    public AttackData Create() => new AttackData(1);
}