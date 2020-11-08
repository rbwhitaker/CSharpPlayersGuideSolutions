using System.Linq.Expressions;

namespace TicTacToe
{

    public class PairOfItems<TFirst, TSecond>
    {
        public TFirst First { get; }
        public TSecond Second { get; }

        public PairOfItems(TFirst first, TSecond second)
        {
            First = first;
            Second = second;
        }

        public PairOfItems()
        {
            First = default(TFirst);
            Second = default;
            System.Boolean.
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            new TicTacToeGame().Run();
        }

    }
}
