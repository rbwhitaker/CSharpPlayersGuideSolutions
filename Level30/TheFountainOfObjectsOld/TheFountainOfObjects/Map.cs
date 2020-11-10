namespace TheFountainOfObjects
{
    public class Map
    {
        public int Rows { get; }
        public int Columns { get; }

        private readonly RoomType[,] _rooms;
        public RoomType GetRoomType(int row, int column) => (row >= 0 && row < Rows && column >= 0 && column < Columns) ? _rooms[row, column] : RoomType.Outside;
        public void SetRoomType(int row, int column, RoomType roomType) => _rooms[row, column] = roomType;

        public Map(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            _rooms = new RoomType[rows, columns];
        }
    }
}
