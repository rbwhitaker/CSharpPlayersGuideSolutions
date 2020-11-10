using System;

namespace TheFountainOfObjects
{
    public class FountainSense : ISense
    {
        public void DisplaySense(FountainOfObjectsGame game)
        {
            if (game.PlayerRoom == RoomType.Fountain)
            {
                if (game.IsFountainOn)
                    ConsoleHelper.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", ConsoleColor.Blue);
                else
                    ConsoleHelper.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.Blue);
            }
        }
    }
}
