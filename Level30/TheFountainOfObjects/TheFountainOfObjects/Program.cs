namespace TheFountainOfObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Map map = new Map(4, 4);
            map.SetRoomTypeAt(0, 0, RoomType.Entrance);
            map.SetRoomTypeAt(1, 1, RoomType.Fountain);
            FountainOfObjectsGame game = new FountainOfObjectsGame(player, map);
            game.Run();
        }
    }
}
