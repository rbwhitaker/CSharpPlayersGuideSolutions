public class VinFletcher : Character
{
    public override string Name => "VIN FLETCHER";

    public VinFletcher() : base(15)
    {
        Attack = new Punch();
        EquippedItem = new VinsBow();
    }
}

public class VinsBow : IEquipment
{
    public string Name => "VIN'S BOW";
    public IAttack Attack { get; } = new QuickShot();
}

public class QuickShot : IAttack
{
    public string Name => "QUICK SHOT";
    public AttackData GenerateData() => new AttackData(3, DamageType.Normal, 0.5f);
}