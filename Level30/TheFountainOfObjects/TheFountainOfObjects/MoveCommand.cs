namespace TheFountainOfObjects
{
    public class MoveCommand : ICommand
    {
        private readonly Direction _direction;
        public MoveCommand(Direction direction)
        {
            _direction = direction;
        }

        public void Execute(FountainOfObjectsGame game)
        {
            int destinationRow = _direction switch { Direction.North => game.Player.Row - 1, Direction.South => game.Player.Row + 1, _ => game.Player.Row };
            int destinationColumn = _direction switch { Direction.East => game.Player.Column + 1, Direction.West => game.Player.Column - 1, _ => game.Player.Column };

            if(game.Map.IsOnMap(destinationRow, destinationColumn))
            {
                game.Player.Row = destinationRow;
                game.Player.Column = destinationColumn;
            }
        }
    }
}
