namespace TheCard
{
    public class Card
    {
        public Rank Rank { get; }
        public Color Color { get; }

        public Card(Rank rank, Color color)
        {
            Rank = rank;
            Color = color;
        }

        public bool IsSymbol => Rank == Rank.Ampersand || Rank == Rank.Caret || Rank == Rank.DollarSign || Rank == Rank.Percent;
        public bool IsNumber => !IsSymbol;
    }
}
