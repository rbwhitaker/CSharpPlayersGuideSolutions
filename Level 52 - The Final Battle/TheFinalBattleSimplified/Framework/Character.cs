using System;

// Represents a single character in the game. Characters should always be of a more specific type than this,
// so this type is abstract.
public abstract class Character
{
    // Produces the name of the character, for display purposes.
    public abstract string Name { get; }

    // Stores the current HP (hit points) of the character. The character dies when this reaches 0.
    private int _hp;

    // Gets or sets the HP of the character, ensuring it never dips below 0 or goes above MaxHP.
    public int HP
    {
        get => _hp;
        set => _hp = Math.Clamp(value, 0, MaxHP);
    }

    // The maximum HP that the character has.
    public int MaxHP { get; set; }

    // Determines if the character is alive or not, as determined by whether they have HP left.
    public bool IsAlive => HP > 0;

    // The equipped item slot that each character has.
    public IEquipment EquippedItem { get; set; }

    public IAttackModifier OffensiveModifier { get; set; }
    public IAttackModifier DefensiveModifier { get; set; }

    public IAttack Attack { get; set; }

    public IAbility Ability { get; set; }

    // Creates a new Character with a specific number of HP (both current HP and MaxHP will be started at this level).
    public Character(int hp)
    {
        MaxHP = hp;
        HP = hp;
    }
}