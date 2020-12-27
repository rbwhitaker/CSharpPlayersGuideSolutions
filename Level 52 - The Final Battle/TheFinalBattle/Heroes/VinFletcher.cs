using System.Collections.Generic;

public class VinFletcher : Companion
{
    public override string Name => "VIN FLETCHER";

    public VinFletcher() : base(15)
    {
        InnateCapabilities = new CapabilitySet(new Punch());
        EquippedItem = new VinsBow();
    }
}

public class VinsBow : IEquipment
{
    public string Name => "VIN'S BOW";
    public ICapabilitySet Capabilities { get; } = new CapabilitySet(new QuickShot());
}

public class QuickShot : IAttack
{
    public string Name => "QUICK SHOT";
    public AttackData GenerateData() => new AttackData(3, DamageType.Normal, 0.5f);
    public List<IAttackSideEffect> SideEffects { get; } = new List<IAttackSideEffect>();
}