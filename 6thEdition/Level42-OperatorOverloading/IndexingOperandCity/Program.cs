BlockCoordinate coordinate = new BlockCoordinate(4, 3);

Console.WriteLine(coordinate[0]);
Console.WriteLine(coordinate[1]);

public enum Direction { North, East, South, West }

public record BlockOffset(int RowOffset, int ColumnOffset);

public record BlockCoordinate(int Row, int Column)
{
    public int this[int index] => index switch { 0 => Row, 1 => Column };
}

// Answer this question: Does an indexer provide many benefits over just refering to the `Row` and `Column`
// properties in this case? Explain your thinking.
//
//    I don't think it does. `coordinate.Row` seems to be more self-explanatory than `coordinate[0]`.
//    I think indexers are more useful when the legal options are not known at compile time. For example,
//    an array or list does not know how many items it will contain until it is running. So to use an
//    indexer makes sense there. A dictionary looks up items based on a key. The keys are not usually
//    known when you are compiling, so an indexer makes sense.