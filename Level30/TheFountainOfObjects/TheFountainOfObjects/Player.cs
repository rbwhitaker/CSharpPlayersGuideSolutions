using System;

namespace TheFountainOfObjects
{
    public class Player
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Command GetCommand()
        {
            Console.Write("> ");
            return Console.ReadLine() switch
            {
                "move north" => new MoveCommand(Direction.North),
                "move south" => new MoveCommand(Direction.South),
                "move east" => new MoveCommand(Direction.East),
                "move west" => new MoveCommand(Direction.West),
                _ => null
            };
        }
    }
}
