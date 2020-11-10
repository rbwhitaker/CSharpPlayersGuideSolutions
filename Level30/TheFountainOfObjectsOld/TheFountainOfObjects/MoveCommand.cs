namespace TheFountainOfObjects
{
    public class MoveCommand : Command
    {
        public Direction Direction { get; }

        public MoveCommand(Direction direction)
        {
            Direction = direction;
        }

        public override void Execute(FountainOfObjectsGame game)
        {
            if (Direction == Direction.North) game.Player.Row--;
            if (Direction == Direction.South) game.Player.Row++;
            if (Direction == Direction.West) game.Player.Column--;
            if (Direction == Direction.East) game.Player.Column++;
        }
    }
}
