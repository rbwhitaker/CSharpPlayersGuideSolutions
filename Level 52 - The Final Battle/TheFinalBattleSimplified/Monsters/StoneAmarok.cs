using System;

public class StoneAmarok : Character
{
    public override string Name => "STONE AMAROK";

    public StoneAmarok() : base(4)
    {
        Attack = new Bite();
        DefensiveModifier = new StoneArmor();
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
}