namespace DuelingTraditions;

// A command that represents a request to turn the fountain on.
public class EnableFountainCommand : ICommand
{
    // Turns the fountain on if the player is in the room with the fountain. Otherwise, nothing happens.
    public void Execute(FountainOfObjectsGame game)
    {
        if (game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Fountain) game.IsFountainOn = true;
        else ConsoleHelper.WriteLine("The fountain is not in this room. There was no effect.", ConsoleColor.Red);
    }
}