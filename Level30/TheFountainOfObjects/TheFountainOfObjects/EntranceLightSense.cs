using System;

namespace TheFountainOfObjects
{
    public class EntranceLightSense : ISense
    {
        public void DisplaySense(FountainOfObjectsGame game)
        {
            if (game.PlayerRoom == RoomType.Entrance)
                ConsoleHelper.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.", ConsoleColor.Yellow);
        }
    }
}
