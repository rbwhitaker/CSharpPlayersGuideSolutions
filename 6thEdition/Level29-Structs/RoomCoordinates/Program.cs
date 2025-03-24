Coordinate a = new Coordinate(3, 3);
Coordinate b = new Coordinate(2, 3);
Coordinate c = new Coordinate(2, 2);

Console.WriteLine(Coordinate.AreAdjacent(a, b)); // Should be True
Console.WriteLine(Coordinate.AreAdjacent(b, c)); // Should be True
Console.WriteLine(Coordinate.AreAdjacent(a, c)); // Should be False
// Console.WriteLine(Coordinate.AreAdjacent(a, a)); // What should this do? Is a coordinate adjacent to itself? It depends on how you want to define it.

public struct Coordinate
{
    public int Row { get; }
    public int Column { get; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public static bool AreAdjacent(Coordinate a, Coordinate b)
    {
        int rowChange = a.Row - b.Row;
        int columnChange = a.Column - b.Column;

        if (Math.Abs(rowChange) <= 1 && columnChange == 0) return true;
        if (Math.Abs(columnChange) <= 1 && rowChange == 0) return true;

        return false;
    }
}