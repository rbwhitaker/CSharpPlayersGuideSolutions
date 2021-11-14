namespace DuelingTraditions;

/// <summary>
/// Represents one of the several monster types in the game.
/// </summary>
public abstract class Monster
{
    // The monster's current location.
    public Location Location { get; set; }

    // Whether the monster is alive or not.
    public bool IsAlive { get; set; } = true;

    // Creates a monster at the given location.
    public Monster(Location start) => Location = start;

    // Called when the monster and the player are both in the same room. Gives
    // the monster a chance to do its thing.
    public abstract void Activate(FountainOfObjectsGame game);
}
