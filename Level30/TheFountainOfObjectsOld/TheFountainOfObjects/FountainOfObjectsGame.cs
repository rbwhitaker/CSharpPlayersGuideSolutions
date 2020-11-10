using System;

namespace TheFountainOfObjects
{
    public class FountainOfObjectsGame
    {
        public Player Player { get; }
        public Map Map { get; }
        public bool IsFountainEnabled { get; set; }

        public FountainOfObjectsGame(Player player, Map map)
        {
            Player = player;
            Map = map;
        }

        public void Run()
        {
            while (!HasWon && !HasLost)
            {
                DisplaySenses();
           
                Command command = Player.GetCommand();
                command?.Execute(this);
            }

            if (HasWon)
            {
                ConsoleHelper.WriteLine("The Fountain of Objects has been reactivated and you have escaped with your life!", ConsoleColor.Magenta);
                ConsoleHelper.WriteLine("You win!", ConsoleColor.Magenta);
            }
            else
            {
                ConsoleHelper.WriteLine("You fell into a pit and died.", ConsoleColor.Magenta);
                ConsoleHelper.WriteLine("You lose.", ConsoleColor.Magenta);
            }
        }

        private void DisplaySenses()
        {
            ConsoleHelper.WriteLine("---------------------------------------------------------------------------------------", ConsoleColor.White);
            ConsoleHelper.WriteLine($"You are in the room at (Row={Player.Row}, Column={Player.Column}).", ConsoleColor.White);

            HandleEntrance();
            HandleFountain();
            HandlePits();
        }

        private void HandleEntrance()
        {
            RoomType currentRoom = PlayerRoom;
            if (currentRoom == RoomType.Entrance) ConsoleHelper.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.", ConsoleColor.Yellow);
        }

        private void HandleFountain()
        {
            RoomType currentRoom = PlayerRoom;
            if (currentRoom == RoomType.Fountain)
            {
                if (IsFountainEnabled) ConsoleHelper.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", ConsoleColor.Cyan);
                else ConsoleHelper.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.Cyan);
            }
        }

        private void HandlePits()
        {
            if (Map.GetRoomType(Player.Row - 1, Player.Column - 1) == RoomType.Pit ||
               Map.GetRoomType(Player.Row - 1, Player.Column) == RoomType.Pit ||
               Map.GetRoomType(Player.Row - 1, Player.Column + 1) == RoomType.Pit ||
               Map.GetRoomType(Player.Row, Player.Column - 1) == RoomType.Pit ||
               Map.GetRoomType(Player.Row, Player.Column) == RoomType.Pit ||
               Map.GetRoomType(Player.Row, Player.Column + 1) == RoomType.Pit ||
               Map.GetRoomType(Player.Row + 1, Player.Column - 1) == RoomType.Pit ||
               Map.GetRoomType(Player.Row + 1, Player.Column) == RoomType.Pit ||
               Map.GetRoomType(Player.Row + 1, Player.Column + 1) == RoomType.Pit)
            {
                ConsoleHelper.WriteLine("You feel a breeze. There is a pit in an adjacent room.", ConsoleColor.Gray);
            }
        }

        public RoomType PlayerRoom => Map.GetRoomType(Player.Row, Player.Column);

        public bool HasWon => PlayerRoom == RoomType.Entrance && IsFountainEnabled;
        public bool HasLost => PlayerRoom == RoomType.Pit;
    }
}
