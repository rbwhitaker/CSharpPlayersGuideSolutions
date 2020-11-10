using System;

namespace TheFountainOfObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayIntroduction();

            Console.Write("Do you want to play a small, medium, or large game? ");
            Map map = Console.ReadLine() switch
            {
                "small" => CreateSmallGame(),
                "medium" => CreateMediumGame(),
                _ => CreateLargeGame()
            };

            Player player = new Player { Row = 2, Column = 2 };
            FountainOfObjectsGame game = new FountainOfObjectsGame(player, map);
            game.Run();
        }

        private static void DisplayIntroduction()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search");
            Console.WriteLine("    of the Fountain of Objects.");
            Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
            Console.WriteLine("You must navigate with your other senses.");
            Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.");
            Console.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room");
            Console.WriteLine("    with a pit, you will die.");
            Console.WriteLine();
            Console.WriteLine("Type 'help' to view the list of commands.");
            Console.WriteLine();

        }
    }
}
