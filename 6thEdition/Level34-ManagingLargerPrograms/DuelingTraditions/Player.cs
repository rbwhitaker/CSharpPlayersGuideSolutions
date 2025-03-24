namespace DuelingTraditions;

// Represents the player in the game.
public class Player
{
    // The player's current location.
    public Location Location { get; set; }

    // Indicates whether the player is alive or not.
    public bool IsAlive { get; private set; } = true;

    // Explains why a player died. Empty string until death.
    public string CauseOfDeath { get; private set; } = "";

    // Creates a new player that starts at the given location.
    public Player(Location start) => Location = start;

    public void Kill(string cause)
    {
        IsAlive = false;
        CauseOfDeath = cause;
    }
}