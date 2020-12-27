public class Skeleton : Character
{
    public override string Name => "SKELETON";
    public Skeleton() : base(5) => Attack = new BoneCrunch();
}

public class BoneCrunch : IAttack
{
    public string Name => "BONE CRUNCH";
    public AttackData GenerateData() => new AttackData(1, DamageType.Normal);
}
