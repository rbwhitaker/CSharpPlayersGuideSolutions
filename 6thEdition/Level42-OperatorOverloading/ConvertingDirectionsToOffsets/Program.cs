Direction direction = Direction.South;
Console.WriteLine(direction);
Console.WriteLine((BlockOffset)direction);

public enum Direction { North, East, South, West }

public record BlockOffset(int RowOffset, int ColumnOffset)
{
    public static implicit operator BlockOffset(Direction direction)
    {
        return direction switch
        {
            Direction.North => new BlockOffset(-1, 0),
            Direction.South => new BlockOffset(+1, 0),
            Direction.West => new BlockOffset(0, -1),
            Direction.East => new BlockOffset(0, +1)
        };
    }
}

public record BlockCoordinate(int Row, int Column);

// Answer this question: This problem didn't call out whether to make the conversion explicit or implicit.
// Which did you choose and why?
//
//    I chose to make it implicit because there was no data loss. But interestingly, in order to
//    actually use the conversion in my main method, I still explicitly stated the cast to get the
//    conversion to happen.