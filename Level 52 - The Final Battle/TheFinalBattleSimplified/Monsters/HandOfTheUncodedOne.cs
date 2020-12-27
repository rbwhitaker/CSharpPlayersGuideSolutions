using System;

public class HandOfTheUncodedOne : Character
{
    public override string Name => "HAND OF THE UNCODED ONE";

    public HandOfTheUncodedOne() : base(25)
    {
        EquippedItem = new BinaryBlade();
        OffensiveModifier = new Corruption();
        Attack = new Punch();
    }
}

public class BinaryBlade : IEquipment
{
    public string Name => "BINARY BLADE";
    public IAttack Attack { get; } = new BitSlash();
}

public class BitSlash : IAttack
{
    private static readonly Random _random = new Random();
    public string Name => "BIT SLASH";
    public AttackData GenerateData() => new AttackData(2 + _random.Next(4), DamageType.Coding);
}

public class Corruption : IAttackModifier
{
    public AttackData Modify(AttackData input, Battle battle, Character attacker, Character target)
    {
        if (input.Type == DamageType.Decoding) return input;

        Console.WriteLine($"{attacker.Name}'s CORRUPTION modifier has changed its attack to a DECODING attack.");
        return input with { Type = DamageType.Decoding };
    }
}