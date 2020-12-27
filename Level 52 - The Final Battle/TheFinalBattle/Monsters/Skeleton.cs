using System.Collections.Generic;

public class Skeleton : Monster
{
    public override string Name => "SKELETON";
    public Skeleton() : base(5) => InnateCapabilities = new CapabilitySet(new BoneCrunch());
}

public class BoneCrunch : IAttack
{
    public string Name => "BONE CRUNCH";
    public AttackData GenerateData() => new AttackData(1, DamageType.Normal);
    public List<IAttackSideEffect> SideEffects { get; } = new List<IAttackSideEffect>();
}
