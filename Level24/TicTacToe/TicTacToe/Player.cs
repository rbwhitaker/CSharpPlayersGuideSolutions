using System;

namespace TicTacToe
{
    public class Player
    {
        public Cell Symbol { get; }
        public Player(Cell symbol)
        {
            Symbol = symbol;
        }

        public Square PickSquare(Board board)
        {
            while (true)
            {
                Console.Write("What square do you want to play in? ");
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine();

                Square choice = key switch
                {
                    ConsoleKey.NumPad7 => new Square(0, 0),
                    ConsoleKey.NumPad8 => new Square(0, 1),
                    ConsoleKey.NumPad9 => new Square(0, 2),
                    ConsoleKey.NumPad4 => new Square(1, 0),
                    ConsoleKey.NumPad5 => new Square(1, 1),
                    ConsoleKey.NumPad6 => new Square(1, 2),
                    ConsoleKey.NumPad1 => new Square(2, 0),
                    ConsoleKey.NumPad2 => new Square(2, 1),
                    ConsoleKey.NumPad3 => new Square(2, 2)
                };

                if (board.IsEmpty(choice.Row, choice.Column))
                    return choice;
                else
                    Console.WriteLine("That square is already taken.");
            }
        }
    }
}
