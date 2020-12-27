using System;
using System.Collections.Generic;

public class StoneAmarok : Monster
{
    public override string Name => "STONE AMAROK";

    public StoneAmarok() : base(4)
    {
        InnateCapabilities.Attacks.Add(new Bite());
        InnateCapabilities.DefensiveModifiers.Add(new StoneArmor());
    }
}

public class StoneArmor : IAttackModifier
{
    public AttackData Modify(AttackData input, Battle battle, Character attacker, Character target)
    {
        AttackData modified = input with { Amount = Math.Max(0, input.Amount - 1) };
        if (modified.Amount < input.Amount)
            ColoredConsole.WriteLine($"{target.Name}'s STONE ARMOR reduced the attack by {input.Amount - modified.Amount}.", ConsoleColor.DarkMagenta);
        return modified;
    }
}

public class Bite : IAttack
{
    public string Name => "BITE";
    public AttackData GenerateData() => new AttackData(2, DamageType.Normal);
    public List<IAttackSideEffect> SideEffects { get; } = new List<IAttackSideEffect>();
}