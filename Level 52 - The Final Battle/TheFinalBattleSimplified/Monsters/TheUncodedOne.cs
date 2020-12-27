using System;

public class TheUncodedOne : Character
{
    public override string Name => "THE UNCODED ONE";
    public TheUncodedOne() : base(100) => Attack = new Deconstruct();
}

public class Deconstruct : IAttack
{
    private static readonly Random _random = new Random();

    public string Name => "DECONSTRUCT";
    public AttackData GenerateData() => new AttackData(_random.Next(3) + 2, DamageType.Decoding);
}