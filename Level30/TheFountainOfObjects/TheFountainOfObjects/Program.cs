using System;

namespace TheFountainOfObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            FountainOfObjectsGame game = null;
            game = LevelGenerator.GenerateGame(game);

            game.Run();
        }
    }
}
