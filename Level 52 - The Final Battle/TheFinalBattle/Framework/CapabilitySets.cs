using System.Collections.Generic;

// A simple capability set with specific items in it.
public class CapabilitySet : ICapabilitySet
{
    // The attacks that are included in the set.
    public List<IAttack> Attacks { get; } = new List<IAttack>();

    // The attack modifiers used when attacking.
    public List<IAttackModifier> OffensiveModifiers { get; } = new List<IAttackModifier>();

    // The attack modifiers used when defending.
    public List<IAttackModifier> DefensiveModifiers { get; } = new List<IAttackModifier>();

    // The abilities in the capability set.
    public List<IAbility> Abilities { get; } = new List<IAbility>();

    // Creates a new, empty capability set. Add new capabilities to the lists afterward.
    public CapabilitySet() { }

    // The following constructors are all utility constructors, meant to make life easier.
    // It is extremely common to want a capability set with only a single capability. These
    // constructors allow you to provide that single item. It creates the new capability
    // set and adds the element to the right collection.

    // Creates a new capability set with a single attack included in it.
    public CapabilitySet(IAttack attack) => Attacks.Add(attack);

    // Creates a new capability set with a single attack modifier in it.
    public CapabilitySet(IAttackModifier modifier, bool isOffensive)
    {
        if (isOffensive) OffensiveModifiers.Add(modifier);
        else DefensiveModifiers.Add(modifier);
    }

    // Creates a new capability set with a single ability included in it.
    public CapabilitySet(IAbility ability) => Abilities.Add(ability);
}


// A capability set that combines the capabilities of multiple other capability sets.
public class CombinedCapabilitySet : ICapabilitySet
{
    // Hangs on to the capability sets that this wraps together.
    private readonly ICapabilitySet[] _components;

    // Creates the capability set, taking in the capability sets that this one should
    // be combining together.
    public CombinedCapabilitySet(params ICapabilitySet[] components) => _components = components;

    // Produces the list of all attacks assembled from all of the contained capability sets.
    public List<IAttack> Attacks
    {
        get
        {
            List<IAttack> attacks = new List<IAttack>();
            foreach (ICapabilitySet component in _components)
                attacks.AddRange(component.Attacks);
            return attacks;
        }
    }

    // Produces the list of all offensive modifiers from all of the contained capability sets.
    public List<IAttackModifier> OffensiveModifiers
    {
        get
        {
            List<IAttackModifier> modifiers = new List<IAttackModifier>();
            foreach (ICapabilitySet component in _components)
                modifiers.AddRange(component.OffensiveModifiers);
            return modifiers;
        }
    }

    // Produces the list of all defensive modifiers from all of the contained capability sets.
    public List<IAttackModifier> DefensiveModifiers
    {
        get
        {
            List<IAttackModifier> modifiers = new List<IAttackModifier>();
            foreach (ICapabilitySet component in _components)
                modifiers.AddRange(component.DefensiveModifiers);
            return modifiers;
        }
    }

    // Produces the list of all abilities from all of the contained capability sets.
    public List<IAbility> Abilities
    {
        get
        {
            List<IAbility> abilities = new List<IAbility>();
            foreach (ICapabilitySet component in _components)
                abilities.AddRange(component.Abilities);
            return abilities;
        }
    }
}
