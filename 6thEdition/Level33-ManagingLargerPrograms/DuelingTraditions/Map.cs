namespace DuelingTraditions;

// Represents one of the different types of rooms in the game.
public enum RoomType { Normal, Entrance, Fountain, OffTheMap }

// Represents a location in the 2D game world, based on its row and column.
public record Location(int Row, int Column);

// Represents the map and what each room is made out of.
public class Map
{
    // Stores which room type each room in the world is. The default is `Normal` because that is the first
    // member in the enumeration list.
    private readonly RoomType[,] _rooms;

    // The total number of rows in this specific game world.
    public int Rows { get; }

    // The total number of columns in this specific game world.
    public int Columns { get; }


    // Creates a new map with a specific size.
    public Map(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _rooms = new RoomType[rows, columns];
    }

    // Returns what type a room at a specific location is.
    public RoomType GetRoomTypeAtLocation(Location location) => IsOnMap(location) ? _rooms[location.Row, location.Column] : RoomType.OffTheMap;

    // Determines if a neighboring room is of the given type.
    public bool HasNeighborWithType(Location location, RoomType roomType)
    {
        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Column - 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Column)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Column + 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row, location.Column - 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row, location.Column)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row, location.Column + 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Column - 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Column)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Column + 1)) == roomType) return true;
        return false;
    }

    // Indicates whether a specific location is actually on the map or not.
    public bool IsOnMap(Location location) =>
        location.Row >= 0 &&
        location.Row < _rooms.GetLength(0) &&
        location.Column >= 0 &&
        location.Column < _rooms.GetLength(1);

    // Changes the type of room at a specific spot in the world to a new type.
    public void SetRoomTypeAtLocation(Location location, RoomType type) => _rooms[location.Row, location.Column] = type;
}