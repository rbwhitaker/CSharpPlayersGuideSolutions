namespace TheFountainOfObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map(5, 5);
            FountainOfObjectsGame game = new FountainOfObjectsGame(map);
            game.Run();
        }
    }
}
