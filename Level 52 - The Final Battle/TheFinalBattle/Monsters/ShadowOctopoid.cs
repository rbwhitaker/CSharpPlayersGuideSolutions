using System;
using System.Collections.Generic;

public class ShadowOctopoid : Monster
{
    public override string Name => "SHADOW OCTOPOID";
    public ShadowOctopoid() : base(7) => InnateCapabilities = new CapabilitySet(new Grapple());
}

public class KnockAway : IAttackSideEffect
{
    private static readonly Random _random = new Random();
    public void Perform(Battle battle, Character attacker, IAttack attack, Character target, AttackData initialData, AttackData finalData)
    {
        if (target.EquippedItem != null && _random.NextDouble() < 0.80)
        {
            ColoredConsole.WriteLine($"{attack.Name} has caused {target.Name} to drop {target.EquippedItem.Name}!", ConsoleColor.Magenta);

            if (attacker.EquippedItem == null && _random.NextDouble() < 0.5)
            {
                ColoredConsole.WriteLine($"{attacker.Name} has retrieved {target.EquippedItem.Name}!", ConsoleColor.Magenta);
                attacker.EquippedItem = target.EquippedItem;
            }
            else
            {
                ColoredConsole.WriteLine($"(Requip {target.EquippedItem.Name} to use it again.)", ConsoleColor.DarkMagenta);
                battle.GetPartyFor(target).SharedInventory.Equipment.Add(target.EquippedItem);
            }

            target.EquippedItem = null;
        }
    }
}

public class Grapple : IAttack
{
    private static readonly Random _random = new Random();
    public string Name => "GRAPPLE";

    public List<IAttackSideEffect> SideEffects => new List<IAttackSideEffect> { new KnockAway() };

    public AttackData GenerateData() => new AttackData(_random.Next(2), DamageType.Normal);
}