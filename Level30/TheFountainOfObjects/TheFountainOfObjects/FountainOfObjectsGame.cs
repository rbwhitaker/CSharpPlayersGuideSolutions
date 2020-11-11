using System;

namespace TheFountainOfObjects
{
    public class FountainOfObjectsGame
    {
        public Maelstrom[] Maelstroms { get; }
        public Player Player { get; }
        public RoomType PlayerRoom => Map.GetRoomTypeAt(Player.Row, Player.Column);
        public Map Map { get; }
        public bool IsFountainOn { get; set; }

        private readonly ISense[] _sensors;

        public FountainOfObjectsGame(Player player, Map map, Maelstrom[] maelstroms)
        {
            Player = player;
            Map = map;
            Maelstroms = maelstroms;

            _sensors = new ISense[] { new CurrentRoomSense(), new EntranceLightSense(), new FountainSense(), new PitSense(), new MaelstromSense() };
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

                foreach (Maelstrom maelstrom in Maelstroms)
                    maelstrom.Activate(this);

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
            Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
            Console.WriteLine("You must navigate the Caverns with your other senses.");
            Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.");
            Console.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a");
            Console.WriteLine("    room with a pit, you will die.");
        }

        private void DisplayEnding()
        {
            if (HasWon)
            {
                ConsoleHelper.WriteLine("The Fountain of Objects has been reactivated and you have escaped with your life!", ConsoleColor.Magenta);
                ConsoleHelper.WriteLine("You win!", ConsoleColor.Magenta);
            }
            else
            {
                ConsoleHelper.WriteLine("You have died in the Cavern of Objects.", ConsoleColor.Magenta);
                ConsoleHelper.WriteLine("You lose.", ConsoleColor.Magenta);
            }
        }

        private void DisplaySenses()
        {
            foreach(ISense sensor in _sensors)
                sensor.DisplaySense(this);
        }

        public bool HasWon => PlayerRoom == RoomType.Entrance && IsFountainOn;
        public bool HasLost => PlayerRoom == RoomType.Pit;
    }
}
