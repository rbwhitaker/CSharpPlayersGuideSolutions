using System;

namespace TheFountainOfObjects
{
    public class Player
    {
        public ICommand GetCommand()
        {
            while (true)
            {
                ConsoleHelper.Write("What do you want to do? ", ConsoleColor.White);
                Console.ForegroundColor = ConsoleColor.Cyan;

                string input = Console.ReadLine();
                ICommand command = input switch
                {
                    "move north" => new MoveCommand(Direction.North),
                    "move south" => new MoveCommand(Direction.South),
                    "move east" => new MoveCommand(Direction.East),
                    "move west" => new MoveCommand(Direction.West),
                    "enable fountain" => new FountainCommand(true),
                    "disable fountain" => new FountainCommand(false),
                    "help" => new HelpCommand(),
                    _ => null
                };

                if(command is HelpCommand)
                {
                    command.Execute(null);
                    continue;
                }
                if (command != null) return command;

                ConsoleHelper.WriteLine($"Unknown command '{input}'. Type 'help' to view available commands.", ConsoleColor.Red);
            }
        }

        public int Row { get; set; }
        public int Column { get; set; }
    }
}
