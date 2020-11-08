namespace TheFountainOfObjects
{
    public class MoveCommand : Command
    {
        public Direction Direction { get; }

        public MoveCommand(Direction direction)
        {
            Direction = direction;
        }
    }
}
