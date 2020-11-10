using System;

namespace TheFountainOfObjects
{
    public class HelpCommand : ICommand
    {
        public void Execute(FountainOfObjectsGame game)
        {
            ConsoleHelper.WriteLine("move north", ConsoleColor.White);
            ConsoleHelper.WriteLine("    Moves you to the room north of your current location.", ConsoleColor.White);
            ConsoleHelper.WriteLine("move south", ConsoleColor.White);
            ConsoleHelper.WriteLine("    Moves you to the room south of your current location.", ConsoleColor.White);
            ConsoleHelper.WriteLine("move east", ConsoleColor.White);
            ConsoleHelper.WriteLine("    Moves you to the room east of your current location.", ConsoleColor.White);
            ConsoleHelper.WriteLine("move west", ConsoleColor.White);
            ConsoleHelper.WriteLine("    Moves you to the room west of your current location.", ConsoleColor.White);
            ConsoleHelper.WriteLine("enable fountain", ConsoleColor.White);
            ConsoleHelper.WriteLine("    Enables the Fountain of Objects, if you are in the same room as it.", ConsoleColor.White);
            ConsoleHelper.WriteLine("disable fountain", ConsoleColor.White);
            ConsoleHelper.WriteLine("    Disables the Fountain of Objects, if you are in the same room as it.", ConsoleColor.White);
            ConsoleHelper.WriteLine("help", ConsoleColor.White);
            ConsoleHelper.WriteLine("    Displays this text.", ConsoleColor.White);
        }
    }
}
