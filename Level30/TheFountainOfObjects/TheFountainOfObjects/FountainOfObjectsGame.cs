using System;

namespace TheFountainOfObjects
{
    public class FountainOfObjectsGame
    {
        public Player Player { get; }
        public RoomType PlayerRoom => Map.GetRoomTypeAt(Player.Row, Player.Column);
        public Map Map { get; }
        public bool IsFountainOn { get; set; }

        private readonly ISense[] _sensors;

        public FountainOfObjectsGame(Player player, Map map)
        {
            Player = player;
            Map = map;
            _sensors = new ISense[] { new CurrentRoomSense(), new EntranceLightSense(), new FountainSense() };
        }

        public void Run()
        {
            DisplayIntroduction();

            while (true)
            {
                ConsoleHelper.WriteLine("----------------------------------------------------------", ConsoleColor.White);
                DisplaySenses();

                ICommand command = Player.GetCommand();
                command.Execute(this);

                if (HasWon || HasLost)
                    break;
            }

            DisplayEnding();
        }

        private void DisplayIntroduction()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search");
            Console.WriteLine("    of the Fountain of Objects.");
            Console.WriteLine("Light is visible only in hte entrance, and no other light is seen anywhere in the caverns.");
            Console.WriteLine("You must navigate the Caverns with your other senses.");
            Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.");
        }

        private void DisplayEnding()
        {
            if (HasWon)
            {
                ConsoleHelper.WriteLine("The Fountain of Objects has been reactivated and you have escaped with your life!", ConsoleColor.Magenta);
                ConsoleHelper.WriteLine("You win!", ConsoleColor.Magenta);
            }
        }

        private void DisplaySenses()
        {
            foreach(ISense sensor in _sensors)
                sensor.DisplaySense(this);
        }

        public bool HasWon => PlayerRoom == RoomType.Entrance && IsFountainOn;
        public bool HasLost => false;
    }
}
