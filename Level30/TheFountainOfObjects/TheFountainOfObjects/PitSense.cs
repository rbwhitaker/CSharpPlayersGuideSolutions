using System;

namespace TheFountainOfObjects
{
    public class PitSense : ISense
    {
        public void DisplaySense(FountainOfObjectsGame game)
        {
            bool nearPit = IsNearPit(game, game.Player.Row, game.Player.Column);
            if (nearPit)
                ConsoleHelper.WriteLine("You feel a draft. There is a pit in a nearby room.", ConsoleColor.Gray);
        }

        private bool IsNearPit(FountainOfObjectsGame game, int row, int column)
        {
            if (IsPit(game, row - 1, column - 1)) return true;
            if (IsPit(game, row - 1, column)) return true;
            if (IsPit(game, row - 1, column + 1)) return true;

            if (IsPit(game, row, column - 1)) return true;
            if (IsPit(game, row, column)) return true;
            if (IsPit(game, row, column + 1)) return true;

            if (IsPit(game, row + 1, column - 1)) return true;
            if (IsPit(game, row + 1, column)) return true;
            if (IsPit(game, row + 1, column + 1)) return true;

            return false;
        }

        private bool IsPit(FountainOfObjectsGame game, int row, int column) => game.Map.GetRoomTypeAt(row, column) == RoomType.Pit;
    }
}
