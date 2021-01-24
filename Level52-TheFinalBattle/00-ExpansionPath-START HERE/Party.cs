using System.Collections.Generic;

/// <summary>
/// Represents a party (of either heroes or monsters). Contains the characters in the party and the player that
/// is running the show for the party.
/// </summary>
public class Party
{
    /// <summary>
    /// The player that is making decisions for this party.
    /// </summary>
    public IPlayer Player { get; set; }

    /// <summary>
    /// The list of characters that are still alive in the party.
    /// </summary>
    public List<Character> Characters { get; } = new List<Character>();
}

