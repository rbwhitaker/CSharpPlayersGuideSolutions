namespace TheFountainOfObjects
{
    public class Map
    {
        public int Rows { get; }
        public int Columns { get; }

        private readonly RoomType[,] _roomTypes;
        public RoomType GetRoomTypeAt(int row, int column) => IsOnMap(row, column) ? _roomTypes[row, column] : RoomType.OffMap;
        public void SetRoomTypeAt(int row, int column, RoomType type) => _roomTypes[row, column] = type;

        public bool IsOnMap(int row, int column) => row >= 0 && row < Rows && column >= 0 && column < Columns;

        public Map(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            _roomTypes = new RoomType[Rows, Columns]; // Default value will be RoomType.Empty.
        }
    }
}
