/// <summary>
/// The main hero and player character of the game.
/// </summary>
public class TheTrueProgrammer : Character
{
    public override string Name { get; }

    public TheTrueProgrammer(string name) : base(25) => Name = name;
    public override IAttack StandardAttack { get; } = new Punch();
}

/// <summary>
/// Punch is a simple attack that reliably deals 1 damage.
/// </summary>
public class Punch : IAttack
{
    public string Name => "PUNCH";
    public AttackData Create() => new AttackData(1);
}