using System;

namespace TheFountainOfObjects
{
    public class FountainOfObjectsGame
    {
        private readonly Player _player;
        private readonly Map _map;

        public FountainOfObjectsGame(Map map)
        {
            _player = new Player();
            _map = map;
        }

        public void Run()
        {
            while (true)
            {
                DisplaySenses();
                Command command = _player.GetCommand();
                ResolveCommand(command);
            }
        }

        private void ResolveCommand(Command command)
        {
            if(command is MoveCommand move)
            {
                if (move.Direction == Direction.North) _player.Row--;
                if (move.Direction == Direction.South) _player.Row++;
                if (move.Direction == Direction.West) _player.Column--;
                if (move.Direction == Direction.East) _player.Column++;
            }
        }

        private void DisplaySenses()
        {
            Console.WriteLine($"You are at Row={_player.Row}, Column={_player.Column}.");
            Console.WriteLine("You sense nothing.");
        }
    }
}
