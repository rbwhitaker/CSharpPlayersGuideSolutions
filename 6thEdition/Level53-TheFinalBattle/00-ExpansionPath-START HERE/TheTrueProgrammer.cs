/// <summary>
/// The main hero and player character of the game.
/// </summary>
public class TheTrueProgrammer(string name) : Character(25)
{
    public override string Name { get; } = name;
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