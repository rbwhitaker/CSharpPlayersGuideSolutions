using System;

namespace TheFountainOfObjects
{
    public static class ConsoleHelper
    {
        public static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
        }
        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }
    }
    public class Player
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Command GetCommand()
        {
            Command command = null;
            do
            {
                ConsoleHelper.Write("What do you want to do? ", ConsoleColor.White);
                Console.ForegroundColor = ConsoleColor.Cyan;
                command = Console.ReadLine() switch
                {
                    "move north" => new MoveCommand(Direction.North),
                    "move south" => new MoveCommand(Direction.South),
                    "move east" => new MoveCommand(Direction.East),
                    "move west" => new MoveCommand(Direction.West),
                    "enable fountain" => new UseFountainCommand(true),
                    "disable fountain" => new UseFountainCommand(false),
                    "help" => new HelpCommand(),
                    _ => null
                };
                if (command == null) ConsoleHelper.WriteLine("That is not a valid command. Type 'help' to view the valid commands.", ConsoleColor.White);
                if(command is HelpCommand help)
                {
                    help.Execute(null);
                    command = null;
                    continue;
                }

            } while (command == null);

            return command;
        }
    }
}
