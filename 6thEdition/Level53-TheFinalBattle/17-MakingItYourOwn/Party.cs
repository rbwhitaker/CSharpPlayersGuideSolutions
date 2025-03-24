
/// <summary>
/// Represents a party (of either heroes or monsters). Contains the characters in the party and the player that
/// is running the show for the party.
/// </summary>
public class Party
{
    /// <summary>
    /// The player that is making decisions for this party.
    /// </summary>
    public IPlayer Player { get; }

    /// <summary>
    /// The list of characters that are still alive in the party.
    /// </summary>
    public List<Character> Characters { get; } = new List<Character>();

    /// <summary>
    /// The items the party has in their collective inventory.
    /// </summary>
    public List<IItem> Items { get; } = new List<IItem>();

    /// <summary>
    /// The gear the party has in their collective inventory.
    /// </summary>
    public List<IGear> Gear { get; } = new List<IGear>();
	
    /// <summary>
    /// Creates a new party with the given player controlling it.
    /// </summary>
    /// <param name="player">The player that will control this party.</param>
    public Party(IPlayer player)
    {
        Player = player;
    }
}

