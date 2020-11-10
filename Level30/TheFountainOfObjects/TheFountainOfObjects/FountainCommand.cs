using System;

namespace TheFountainOfObjects
{
    public class FountainCommand : ICommand
    { 
        public bool ShouldEnable { get; }
        
        public FountainCommand(bool shouldEnable)
        {
            ShouldEnable = shouldEnable;
        }

        public void Execute(FountainOfObjectsGame game)
        {
            if (game.PlayerRoom == RoomType.Fountain)
                game.IsFountainOn = ShouldEnable;
            else
                ConsoleHelper.WriteLine("You can only perform that action in the room with the Fountain of Objects.", ConsoleColor.Red);
        }
    }
}
