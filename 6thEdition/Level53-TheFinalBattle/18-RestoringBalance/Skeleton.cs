/// <summary>
/// A character that represents a skeleton--a simple monster type with a bone crunch attack.
/// </summary>
public class Skeleton : Character
{
    public override string Name => "SKELETON";
    public override IAttack StandardAttack { get; } = new BoneCrunch();

    public Skeleton() : base(5) { }
}

public class Dagger : IGear
{
    public string Name => "DAGGER";
    public IAttack Attack { get; } = new Stab();
}

public class Stab : IAttack
{
    public string Name => "STAB";
    public AttackData Create() => new AttackData(1);
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
