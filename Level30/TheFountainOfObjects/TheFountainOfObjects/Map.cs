namespace TheFountainOfObjects
{
    public class Map
    {
        public int Rows { get; }
        public int Columns { get; }
        public RoomType GetRoomType(int row, int column) => RoomType.Empty;

        public Map(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }
    }
}
