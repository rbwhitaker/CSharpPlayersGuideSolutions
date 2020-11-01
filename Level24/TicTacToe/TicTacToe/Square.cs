namespace TicTacToe
{
    // This wasn't in my CRC card design, but it maybe should have been.
    public class Square
    {
        public int Row { get; }
        public int Column { get; }

        public Square(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
