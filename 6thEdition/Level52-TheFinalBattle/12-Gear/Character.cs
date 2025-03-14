/// <summary>
/// Defines what all characters in the game have in common.
/// </summary>
public abstract class Character
{
    /// <summary>
    /// The name of the character.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// The character's standard attack.
    /// </summary>
    public abstract IAttack StandardAttack { get; }

    /// <summary>
    /// The gear the character has attached. If it exists, it provides a second special attack.
    /// </summary>
    public IGear? EquippedGear { get; set; }

    // Stores the hit points remaining for the character.
    private int _hp;

    /// <summary>
    /// Gets or sets the current hit points for the character, ensuring it always stays at or above 0 and at or below MaxHP.
    /// </summary>
    public int HP
    {
        get => _hp;
        set => _hp = Math.Clamp(value, 0, MaxHP);
    }

    /// <summary>
    /// The maximum HP that the character has.
    /// </summary>
    public int MaxHP { get; }

    /// <summary>
    /// Indicates if the character is alive or not.
    /// </summary>
    public bool IsAlive => HP > 0;

    /// <summary>
    /// Creates a new character with a specific amount of HP. The character will start with both HP and MaxHP at this level.
    /// </summary>
    public Character(int hp)
    {
        MaxHP = hp;
        HP = hp;
    }
}