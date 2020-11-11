using System;

namespace TheFountainOfObjects
{
    public class Maelstrom
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public void Activate(FountainOfObjectsGame game)
        {
            if (game.Player.Row == Row && game.Player.Column == Column)
                MovePlayer(game);
        }

        private Direction _nextDirection = Direction.East;

        public void MovePlayer(FountainOfObjectsGame game)
        {
            ConsoleHelper.WriteLine("You have encountered a maelstrom! It moves you to another room in the caverns.", ConsoleColor.DarkGreen);
            PerformMove(game);
            WrapAround(game);
            MoveToNextDirection();
        }

        private void PerformMove(FountainOfObjectsGame game)
        {
            if (_nextDirection == Direction.East)
            {
                game.Player.Column += 2;
                Column -= 1;
            }
            else if (_nextDirection == Direction.South)
            {
                game.Player.Row += 2;
                Row -= 1;
            }
            else if (_nextDirection == Direction.West)
            {
                game.Player.Column -= 2;
                Column += 1;
            }
            else if (_nextDirection == Direction.North)
            {
                game.Player.Row -= 2;
                Row += 1;
            }
        }

        private void WrapAround(FountainOfObjectsGame game)
        {
            if (game.Player.Column < 0) game.Player.Column += game.Map.Columns;
            if (game.Player.Column >= game.Map.Columns) game.Player.Column -= game.Map.Columns;
            if (game.Player.Row < 0) game.Player.Row += game.Map.Rows;
            if (game.Player.Row >= game.Map.Rows) game.Player.Row -= game.Map.Rows;

            if (Column < 0) Column += game.Map.Columns;
            if (Column >= game.Map.Columns) Column -= game.Map.Columns;
            if (Row < 0) Row += game.Map.Rows;
            if (Row >= game.Map.Rows) Row -= game.Map.Rows;
        }

        private void MoveToNextDirection()
        {
            _nextDirection = _nextDirection switch
            {
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                Direction.North => Direction.East
            };
        }
    }
}
