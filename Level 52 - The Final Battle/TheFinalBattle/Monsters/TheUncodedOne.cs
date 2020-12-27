using System;
using System.Collections.Generic;

public class TheUncodedOne : Monster
{
    public override string Name => "THE UNCODED ONE";
    public TheUncodedOne() : base(100) => InnateCapabilities = new CapabilitySet(new Deconstruct());
}

public class Deconstruct : IAttack
{
    private static readonly Random _random = new Random();

    public string Name => "DECONSTRUCT";
    public AttackData GenerateData() => new AttackData(_random.Next(3) + 2, DamageType.Decoding);
    public List<IAttackSideEffect> SideEffects { get; } = new List<IAttackSideEffect>();
}