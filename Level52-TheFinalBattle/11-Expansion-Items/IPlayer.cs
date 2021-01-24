/// <summary>
/// Represents a player--one of entities that control characters and pick actions for them when it is the character's turn.
/// </summary>
public interface IPlayer
{
    /// <summary>
    /// Allows the player to choose an action for a given character. The battle is provided as context, so that it has the
    /// information it needs to make good decisions.
    /// </summary>
    IAction ChooseAction(Battle battle, Character character);
}

