/// <summary>
/// Represents a party (of either heroes or monsters). Contains the characters in the party and the player that
/// is running the show for the party.
/// </summary>
/// <remarks>
/// Creates a new party with the given player controlling it.
/// </remarks>
/// <param name="player">The player that will control this party.</param>
public class Party(IPlayer player)
{
    /// <summary>
    /// The player that is making decisions for this party.
    /// </summary>
    public IPlayer Player { get; } = player;

    /// <summary>
    /// The list of characters that are still alive in the party.
    /// </summary>
    public List<Character> Characters { get; } = [];
}

