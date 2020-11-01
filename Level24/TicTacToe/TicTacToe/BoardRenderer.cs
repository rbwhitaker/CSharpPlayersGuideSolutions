using System;

namespace TicTacToe
{
    public class BoardRenderer
    {
        public void Draw(Board board)
        {
            char[,] symbols = new char[3, 3];
            symbols[0, 0] = GetCharacterFor(board.ContentsOf(0, 0));
            symbols[0, 1] = GetCharacterFor(board.ContentsOf(0, 1));
            symbols[0, 2] = GetCharacterFor(board.ContentsOf(0, 2));
            symbols[1, 0] = GetCharacterFor(board.ContentsOf(1, 0));
            symbols[1, 1] = GetCharacterFor(board.ContentsOf(1, 1));
            symbols[1, 2] = GetCharacterFor(board.ContentsOf(1, 2));
            symbols[2, 0] = GetCharacterFor(board.ContentsOf(2, 0));
            symbols[2, 1] = GetCharacterFor(board.ContentsOf(2, 1));
            symbols[2, 2] = GetCharacterFor(board.ContentsOf(2, 2));

            Console.WriteLine($" {symbols[0, 0]} | {symbols[0, 1]} | {symbols[0, 2]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {symbols[1, 0]} | {symbols[1, 1]} | {symbols[1, 2]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {symbols[2, 0]} | {symbols[2, 1]} | {symbols[2, 2]}");
        }

        private char GetCharacterFor(Cell cell) => cell switch { Cell.X => 'X', Cell.O => 'O', Cell.Empty => ' ' };
    }
}
