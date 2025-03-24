namespace DuelingTraditions;

// Represents the player's ability to sense the light in the entrance room.
public class LightInEntranceSense : ISense
{
    // Returns `true` if the player is in the entrance room.
    public bool CanSense(FountainOfObjectsGame game) => game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Entrance;

    // Displays the appropriate message if the player can see the light from outside the caverns.
    public void DisplaySense(FountainOfObjectsGame game) => ConsoleHelper.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.", ConsoleColor.Yellow);
}
