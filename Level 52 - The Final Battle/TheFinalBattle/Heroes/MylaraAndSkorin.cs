using System.Collections.Generic;

public class MylaraAndSkorin : Companion
{
    public override string Name => "MYLARA and SKORIN";

    public MylaraAndSkorin() : base(20)
    {
        InnateCapabilities = new CapabilitySet(new Punch());
        EquippedItem = new CannonOfConsolas();
    }
}

public class CannonOfConsolas : IEquipment
{
    public string Name => "CANNON OF CONSOLAS";

    public ICapabilitySet Capabilities { get; } = new CapabilitySet(new CannonBlast());
}

public class CannonBlast : IAttack
{
    public string Name => "CANNON BLAST";

    private int _timesUsed = 0;
    public AttackData GenerateData()
    {
        _timesUsed++;

        if (_timesUsed % 5 == 0 && _timesUsed % 3 == 0) return new AttackData(5, DamageType.Explosive, 0.75f);
        if (_timesUsed % 5 == 0) return new AttackData(2, DamageType.Fire, 0.75f);
        if (_timesUsed % 3 == 0) return new AttackData(2, DamageType.Electric, 0.75f);
        return new AttackData(1, DamageType.Normal, 0.75f);
    }
    public List<IAttackSideEffect> SideEffects { get; } = new List<IAttackSideEffect>();
}