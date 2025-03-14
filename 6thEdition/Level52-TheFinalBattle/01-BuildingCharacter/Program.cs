Party heroes = new Party();
heroes.Characters.Add(new Skeleton());

Party monsters = new Party();
monsters.Characters.Add(new Skeleton());

Battle battle = new Battle(heroes, monsters);
battle.Run();

public class Battle
{
    private Party Heroes;
    private Party Monsters;

    public Battle(Party heroes, Party monsters)
    {
        Heroes = heroes;
        Monsters = monsters;
    }

    public void Run()
    {
        while (true)
        {
            foreach (Party party in new[] { Heroes, Monsters })
            {
                foreach (Character character in party.Characters)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{character.Name} is taking a turn...");
                    Thread.Sleep(500);
                    character.TakeTurn();
                }
            }
        }
    }
}

public class Party
{
    public List<Character> Characters { get; } = new List<Character>();
}

public abstract class Character
{
    public abstract string Name { get; }
    public void TakeTurn() => Console.WriteLine($"{Name} did NOTHING.");
}

public class Skeleton : Character
{
    public override string Name => "SKELETON";
}