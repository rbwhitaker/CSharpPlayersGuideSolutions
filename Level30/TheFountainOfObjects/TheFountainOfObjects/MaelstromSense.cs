using System;

namespace TheFountainOfObjects
{
    public class MaelstromSense : ISense
    {
        public void DisplaySense(FountainOfObjectsGame game)
        {
            bool nearMaelstrom = false;

            foreach (Maelstrom maelstrom in game.Maelstroms)
                if (Math.Abs(maelstrom.Row - game.Player.Row) <= 1 && Math.Abs(maelstrom.Column - game.Player.Column) <= 1)
                    nearMaelstrom = true;

            if (nearMaelstrom)
                ConsoleHelper.WriteLine("You hear the growling and groaning of a maelstrom nearby.", ConsoleColor.DarkGreen);
        }
    }
}
