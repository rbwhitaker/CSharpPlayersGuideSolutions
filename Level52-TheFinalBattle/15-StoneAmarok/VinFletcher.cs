/// <summary>
/// A hero companion that has a bow that misses sometimes, but when he hits, deals a lot of damage.
/// </summary>
public class VinFletcher : Character
{
    public override string Name => "VIN FLETCHER";
    public override IAttack StandardAttack { get; } = new Punch();
    public VinFletcher() : base(15) => EquippedGear = new VinsBow();
}

public class VinsBow : IGear
{
    public string Name => "VIN'S BOW";
    public IAttack Attack => new QuickShot();
}

public class QuickShot : IAttack
{
    public string Name => "QUICK SHOT";
    public AttackData Create() => new AttackData(3, 0.5);
}