using System;

namespace TheFountainOfObjects
{
    public class HelpCommand : Command
    {
        public override void Execute(FountainOfObjectsGame game)
        {
            ConsoleHelper.WriteLine("move north", ConsoleColor.White);
            ConsoleHelper.WriteLine("    Moves to the room north of the current room.", ConsoleColor.White);
            ConsoleHelper.WriteLine("move south", ConsoleColor.White);
            ConsoleHelper.WriteLine("    Moves to the room south of the current room.", ConsoleColor.White);
            ConsoleHelper.WriteLine("move east", ConsoleColor.White);
            ConsoleHelper.WriteLine("    Moves to the room east of the current room.", ConsoleColor.White);
            ConsoleHelper.WriteLine("move west", ConsoleColor.White);
            ConsoleHelper.WriteLine("    Moves to the room west of the current room.", ConsoleColor.White);
            ConsoleHelper.WriteLine("enable fountain", ConsoleColor.White);
            ConsoleHelper.WriteLine("    Turns the Fountain of Objects on, but only if you are in the same room as it.", ConsoleColor.White);
            ConsoleHelper.WriteLine("disable fountain", ConsoleColor.White);
            ConsoleHelper.WriteLine("    Turns the Fountain of Objects off, but only if you are in the same room as it.", ConsoleColor.White);

        }
    }
    public class UseFountainCommand : Command
    {
        public bool Enable { get; }

        public UseFountainCommand(bool enable) => Enable = enable;

        public override void Execute(FountainOfObjectsGame game)
        {
            if(game.Map.GetRoomType(game.Player.Row, game.Player.Column) == RoomType.Fountain)
                game.IsFountainEnabled = Enable;
        }
    }
}
