string name = ColoredConsole.Prompt("What is your name?").ToUpper();

Party heroes = new Party(new ComputerPlayer());
heroes.Characters.Add(new TheTrueProgrammer(name));

Party monsters = new Party(new ComputerPlayer());
monsters.Characters.Add(new Skeleton());

Battle battle = new Battle(heroes, monsters);
battle.Run();

public class Battle
{
    private Party Heroes { get; }
    private Party Monsters { get; }

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
                    party.Player.ChooseAction(this, character).Run(this, character);
                }
            }
        }
    }

    public Party GetEnemyPartyFor(Character character) => Heroes.Characters.Contains(character) ? Monsters : Heroes;
    public Party GetPartyFor(Character character) => Heroes.Characters.Contains(character) ? Heroes : Monsters;
}

public interface IAction
{
    void Run(Battle battle, Character actor);
}

public interface IPlayer
{
    IAction ChooseAction(Battle battle, Character character);
}

public class DoNothingAction : IAction
{
    public void Run(Battle battle, Character actor) => Console.WriteLine($"{actor.Name} did NOTHING.");
}

public class AttackAction : IAction
{
    private readonly IAttack _attack;
    private readonly Character _target;

    public AttackAction(IAttack attack, Character target)
    {
        _attack = attack;
        _target = target;
    }

    public void Run(Battle battle, Character character)
    {
        Console.WriteLine($"{character.Name} used {_attack.Name} on {_target.Name}.");
    }
}

public class ComputerPlayer : IPlayer
{
    public IAction ChooseAction(Battle battle, Character character)
    {
        Thread.Sleep(500);
        return new AttackAction(character.StandardAttack, battle.GetEnemyPartyFor(character).Characters[0]);
    }
}

public class Party
{
    public IPlayer Player { get; }
    public List<Character> Characters { get; } = new List<Character>();

    public Party(IPlayer player)
    {
        Player = player;
    }
}

public interface IAttack
{
    string Name { get; }
}

public abstract class Character
{
    public abstract string Name { get; }
    public abstract IAttack StandardAttack { get; }
}

public class Skeleton : Character
{
    public override string Name => "SKELETON";
    public override IAttack StandardAttack { get; } = new BoneCrunch();
}

public class BoneCrunch : IAttack
{
    public string Name => "BONE CRUNCH";
}

public class TheTrueProgrammer : Character
{
    public override string Name { get; }

    public TheTrueProgrammer(string name) => Name = name;
    public override IAttack StandardAttack { get; } = new Punch();
}

public class Punch : IAttack
{
    public string Name => "PUNCH";
}

public static class ColoredConsole
{
    public static void WriteLine(string text, ConsoleColor color)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = previousColor;
    }

    public static void Write(string text, ConsoleColor color)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = previousColor;
    }

    public static string Prompt(string questionToAsk)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(questionToAsk + " ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string input = Console.ReadLine() ?? ""; // If we got null, use empty string instead.
        Console.ForegroundColor = previousColor;
        return input;
    }
}
