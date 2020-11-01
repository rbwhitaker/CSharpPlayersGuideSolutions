using System;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public void Run()
        {
            Board board = new Board();
            BoardRenderer renderer = new BoardRenderer();
            Player player1 = new Player(Cell.X);
            Player player2 = new Player(Cell.O);
            int turnNumber = 0;

            Player currentPlayer = player1;

            while(turnNumber < 9) // After 9 moves, if nobody has won, the game is a draw.
            {
                renderer.Draw(board);
                Console.WriteLine($"It is {currentPlayer.Symbol}'s turn.");
                Square square = currentPlayer.PickSquare(board);
                board.FillCell(square.Row, square.Column, currentPlayer.Symbol);
                if(HasWon(board, Cell.X))
                {
                    renderer.Draw(board);
                    Console.WriteLine("X Won!");
                    return;
                }
                else if(HasWon(board, Cell.O))
                {
                    renderer.Draw(board);
                    Console.WriteLine("O Won!");
                    return;
                }

                // Change to the other player.
                currentPlayer = currentPlayer == player1 ? player2 : player1;
                turnNumber++;
            }

            renderer.Draw(board);
            Console.WriteLine("Draw!");
        }

        private bool HasWon(Board board, Cell value)
        {
            // Check rows.
            if(board.ContentsOf(0, 0) == value && board.ContentsOf(0, 1) == value && board.ContentsOf(0, 2) == value) return true;
            if(board.ContentsOf(1, 0) == value && board.ContentsOf(1, 1) == value && board.ContentsOf(1, 2) == value) return true;
            if(board.ContentsOf(2, 0) == value && board.ContentsOf(2, 1) == value && board.ContentsOf(2, 2) == value) return true;

            // Check columns.
            if (board.ContentsOf(0, 0) == value && board.ContentsOf(1, 0) == value && board.ContentsOf(2, 0) == value) return true;
            if (board.ContentsOf(0, 1) == value && board.ContentsOf(1, 1) == value && board.ContentsOf(2, 1) == value) return true;
            if (board.ContentsOf(0, 2) == value && board.ContentsOf(1, 2) == value && board.ContentsOf(2, 2) == value) return true;

            // Check diagonals.
            if (board.ContentsOf(0, 0) == value && board.ContentsOf(1, 1) == value && board.ContentsOf(2, 2) == value) return true;
            if (board.ContentsOf(2, 0) == value && board.ContentsOf(1, 1) == value && board.ContentsOf(0, 2) == value) return true;

            return false;
        }
    }
}
