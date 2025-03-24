namespace DuelingTraditions;

// Represents the player's ability to sense the dripping of a deactivated fountain or rushing waters of an activated fountain.
public class FountainSense : ISense
{
    // Returns `true` if the player is in the fountain room.
    public bool CanSense(FountainOfObjectsGame game) => game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Fountain;

    // Displays the appropriate message depending on whether the fountain is enabled or disabled.
    public void DisplaySense(FountainOfObjectsGame game)
    {
        if (game.IsFountainOn) ConsoleHelper.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", ConsoleColor.DarkCyan);
        else ConsoleHelper.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.DarkCyan);
    }
}