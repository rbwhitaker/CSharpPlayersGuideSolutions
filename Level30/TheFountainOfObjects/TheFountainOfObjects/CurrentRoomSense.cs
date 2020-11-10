using System;

namespace TheFountainOfObjects
{
    public class CurrentRoomSense : ISense
    {
        public void DisplaySense(FountainOfObjectsGame game) => ConsoleHelper.WriteLine($"You are in the room at (Row={game.Player.Row}, Column={game.Player.Column}).", ConsoleColor.White);
    }
}
