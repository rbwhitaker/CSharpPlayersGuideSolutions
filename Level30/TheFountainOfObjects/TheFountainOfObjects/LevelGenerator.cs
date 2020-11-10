using System;

namespace TheFountainOfObjects
{
    public static class LevelGenerator
    {
        public static FountainOfObjectsGame GenerateGame(FountainOfObjectsGame game)
        {
            while (game == null)
            {
                ConsoleHelper.Write("Do you want to play a small, medium, or large game? ", ConsoleColor.White);
                game = Console.ReadLine() switch
                {
                    "small" => CreateSmallGame(),
                    "medium" => CreateMediumGame(),
                    "large" => CreateLargeGame(),
                    _ => null
                };
            }

            return game;
        }

        public static FountainOfObjectsGame CreateSmallGame()
        {
            Map map = new Map(4, 4);
            map.SetRoomTypeAt(1, 1, RoomType.Fountain);
            map.SetRoomTypeAt(0, 3, RoomType.Pit);

            map.SetRoomTypeAt(0, 0, RoomType.Entrance);
            Player player = new Player();
            player.Row = 0;
            player.Column = 0;

            return new FountainOfObjectsGame(player, map);
        }

        public static FountainOfObjectsGame CreateMediumGame()
        {
            Map map = new Map(6, 6);
            map.SetRoomTypeAt(4, 2, RoomType.Fountain);
            map.SetRoomTypeAt(3, 0, RoomType.Pit);
            map.SetRoomTypeAt(0, 2, RoomType.Pit);


            map.SetRoomTypeAt(0, 5, RoomType.Entrance);
            Player player = new Player();
            player.Row = 0;
            player.Column = 5;

            return new FountainOfObjectsGame(player, map);
        }

        public static FountainOfObjectsGame CreateLargeGame()
        {
            Map map = new Map(8, 8);
            map.SetRoomTypeAt(4, 2, RoomType.Fountain);
            map.SetRoomTypeAt(7, 0, RoomType.Pit);
            map.SetRoomTypeAt(4, 5, RoomType.Pit);
            map.SetRoomTypeAt(4, 0, RoomType.Pit);
            map.SetRoomTypeAt(3, 2, RoomType.Pit);

            map.SetRoomTypeAt(3, 7, RoomType.Entrance);
            Player player = new Player();
            player.Row = 3;
            player.Column = 7;

            return new FountainOfObjectsGame(player, map);
        }
    }
}
