/// <summary>
/// A character that represents a skeleton--a simple monster type with a bone crunch attack.
/// </summary>
public class Skeleton : Character
{
    public override string Name => "SKELETON";
    public override IAttack StandardAttack { get; } = new BoneCrunch();

    public Skeleton() : base(5) { }
}

/// <summary>
/// An attack that deals 0 or 1 damage randomly.
/// </summary>
public class BoneCrunch : IAttack
{
    private static readonly Random _random = new Random();

    public string Name => "BONE CRUNCH";
    public AttackData Create() => new AttackData(_random.Next(2));
}
