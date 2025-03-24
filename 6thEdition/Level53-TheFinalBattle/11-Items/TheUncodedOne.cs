/// <summary>
/// The character that represents the big bad evil in the game.
/// </summary>
public class TheUncodedOne : Character
{
    public override string Name => "THE UNCODED ONE";
    public TheUncodedOne() : base(15) { }
    public override IAttack StandardAttack { get; } = new Unraveling();
}

/// <summary>
/// An attack that deals 0 to 2 damage randomly.
/// </summary>
public class Unraveling : IAttack
{
    private static readonly Random _random = new Random();
    public string Name => "UNRAVELING";
    public AttackData Create() => new AttackData(_random.Next(3));
}