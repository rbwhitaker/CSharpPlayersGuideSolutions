﻿using System;
using System.Collections.Generic;

public class PlayerCharacter : Hero
{
    public override string Name { get; }

    public PlayerCharacter(string name) : base(25)
    {
        Name = name;
        InnateCapabilities.Attacks.Add(new Punch());
        InnateCapabilities.DefensiveModifiers.Add(new ObjectSight());
        EquippedItem = new Sword(name + "'s SWORD");
    }
}

public class Sword : IEquipment
{
    public string Name { get; }
    public Sword(string name) => Name = name;
    public ICapabilitySet Capabilities { get; } = new CapabilitySet(new Slash());
}

public class Slash : IAttack
{
    public string Name => "SLASH";
    public AttackData GenerateData() => new AttackData(2, DamageType.Normal);
    public List<IAttackSideEffect> SideEffects { get; } = new List<IAttackSideEffect>();
}

public class ObjectSight : IAttackModifier
{
    public AttackData Modify(AttackData input, Battle battle, Character attacker, Character target)
    {
        if (input.Type != DamageType.Decoding) return input;

        AttackData modified = input with { Amount = Math.Max(input.Amount - 2, 0) };

        ColoredConsole.WriteLine($"{target.Name}'s OBJECT SIGHT reduced the DECODING attack by {input.Amount - modified.Amount}.", ConsoleColor.DarkMagenta);
        return modified;
    }
}