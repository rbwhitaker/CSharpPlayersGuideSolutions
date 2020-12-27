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

    // Lists the capabilities that the character has innately--provided by the character itself, rather
    // than items they are carrying.
    public ICapabilitySet InnateCapabilities { get; set; } = new CapabilitySet();

    // Lists all capabilities that the character has, including innate capabilities, as well as ones
    // provided by equipped items, or other sources.
    public ICapabilitySet AllCapabilities => EquippedItem == null ? InnateCapabilities : new CombinedCapabilitySet(EquippedItem.Capabilities, InnateCapabilities);

    // Creates a new Character with a specific number of HP (both current HP and MaxHP will be started at this level).
    public Character(int hp)
    {
        MaxHP = hp;
        HP = hp;
    }
}