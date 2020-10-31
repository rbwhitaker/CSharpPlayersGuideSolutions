using System;

namespace TheCard
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int colorNumber = 0; colorNumber < 4; colorNumber++)
            {
                for (int rankNumber = 0; rankNumber < 14; rankNumber++)
                {
                    Rank rank = LookupRankByNumber(rankNumber);
                    Color color = LookupColorByNumber(colorNumber);
                    Card card = new Card(rank, color);
                    Console.WriteLine($"The {card.Color} {card.Rank}");
                }
            }
        }

        // If you read the Side Quest section about enumerations and integers, you can probably dream up a more concise way to create this code.
        private static Rank LookupRankByNumber(int number) => number switch
        {
            0 => Rank.One,
            1 => Rank.Two,
            2 => Rank.Three,
            3 => Rank.Four,
            4 => Rank.Five,
            5 => Rank.Six,
            6 => Rank.Seven,
            7 => Rank.Eight,
            8 => Rank.Nine,
            9 => Rank.Ten,
            10 => Rank.DollarSign,
            11 => Rank.Percent,
            12 => Rank.Caret,
            13 => Rank.Ampersand
        };

        // If you read the Side Quest section about enumerations and integers, you can probably dream up a more concise way to create this code.
        private static Color LookupColorByNumber(int number) => number switch
        {
            0 => Color.Red,
            1 => Color.Green,
            2 => Color.Blue,
            3 => Color.Yellow
        };
    }
}