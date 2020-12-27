using System.Collections.Generic;

public interface ICapabilitySet
{
    List<IAttack> Attacks { get; }
    List<IAttackModifier> OffensiveModifiers { get; }
    List<IAttackModifier> DefensiveModifiers { get; }
    List<IAbility> Abilities { get; }
}
