public class TheHandOfTheUncodedOne : Character
{
    public override string Name => "THE HAND OF THE UNCODED ONE";
    public TheHandOfTheUncodedOne() : base(25)
    {
        EquippedGear = new BinaryBlade();
    }
    public override IAttack StandardAttack { get; } = new Punch();
}

public class BinaryBlade : IGear
{
    public string Name => "BINARY BLADE";

    public IAttack Attack { get; } = new BitSlash();
}

public class BitSlash : IAttack
{
    private static readonly Random _random = new Random();
    public string Name => "BIT SLASH";
    public AttackData Create() => new AttackData(_random.Next(3) + 1, Type: DamageType.Coding);
}