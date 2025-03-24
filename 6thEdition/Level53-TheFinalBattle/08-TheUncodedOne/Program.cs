string name = ColoredConsole.Prompt("What is your name?").ToUpper();

IPlayer player1 = new ComputerPlayer();
IPlayer player2 = new ComputerPlayer();

Party heroes = new Party(player1);
heroes.Characters.Add(new TheTrueProgrammer(name));

List<Party> monsterParties = new List<Party> { CreateMonsterParty1(player2), CreateMonsterParty2(player2), CreateMonsterParty3(player2) };

for (int battleNumber = 0; battleNumber < monsterParties.Count; battleNumber++)
{
    Party monsters = monsterParties[battleNumber];
    Battle battle = new Battle(heroes, monsters);
    battle.Run();

    if (heroes.Characters.Count == 0) break;
}

if (heroes.Characters.Count > 0) ColoredConsole.WriteLine("You have defeated the Uncoded One's forces! You have won the battle!", ConsoleColor.Green);
else ColoredConsole.WriteLine("You have been defeated. The Uncoded One has won.", ConsoleColor.Red);


Party CreateMonsterParty1(IPlayer controllingPlayer)
{
    Party monsters = new Party(controllingPlayer);
    monsters.Characters.Add(new Skeleton());
    return monsters;
}

Party CreateMonsterParty2(IPlayer controllingPlayer)
{
    Party monsters = new Party(controllingPlayer);
    monsters.Characters.Add(new Skeleton());
    monsters.Characters.Add(new Skeleton());
    return monsters;
}

Party CreateMonsterParty3(IPlayer controllingPlayer)
{
    Party monsters = new Party(controllingPlayer);
    monsters.Characters.Add(new TheUncodedOne());
    return monsters;
}

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
        while (!IsOver)
        {
            foreach (Party party in new[] { Heroes, Monsters })
            {
                foreach (Character character in party.Characters)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{character.Name} is taking a turn...");
                    party.Player.ChooseAction(this, character).Run(this, character);

                    if (IsOver) break;
                }

                if (IsOver) break;
            }
        }
    }

    public bool IsOver => Heroes.Characters.Count == 0 || Monsters.Characters.Count == 0;

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

        AttackData data = _attack.Create();
        _target.HP -= data.Damage;

        Console.WriteLine($"{_attack.Name} dealt {data.Damage} damage to {_target.Name}.");
        Console.WriteLine($"{_target.Name} is now at {_target.HP}/{_target.MaxHP} HP.");

        if (!_target.IsAlive)
        {
            battle.GetPartyFor(_target).Characters.Remove(_target);
            Console.WriteLine($"{_target.Name} was defeated!");
        }
    }
}

public class ComputerPlayer : IPlayer
{
    public IAction ChooseAction(Battle battle, Character character)
    {
        Thread.Sleep(500);
        List<Character> potentialTargets = battle.GetEnemyPartyFor(character).Characters;
        if (potentialTargets.Count > 0) return new AttackAction(character.StandardAttack, battle.GetEnemyPartyFor(character).Characters[0]);
        return new DoNothingAction();

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

public record AttackData(int Damage);

public interface IAttack
{
    string Name { get; }
    AttackData Create();
}

public abstract class Character
{
    public abstract string Name { get; }
    public abstract IAttack StandardAttack { get; }

    private int _hp;
    public int HP
    {
        get => _hp;
        set => _hp = Math.Clamp(value, 0, MaxHP);
    }

    public int MaxHP { get; }

    public bool IsAlive => HP > 0;

    public Character(int hp)
    {
        MaxHP = hp;
        HP = hp;
    }
}

public class Skeleton : Character
{
    public override string Name => "SKELETON";
    public override IAttack StandardAttack { get; } = new BoneCrunch();

    public Skeleton() : base(5) { }
}

public class BoneCrunch : IAttack
{
    private static readonly Random _random = new Random();

    public string Name => "BONE CRUNCH";
    public AttackData Create() => new AttackData(_random.Next(2));
}

public class TheTrueProgrammer : Character
{
    public override string Name { get; }

    public TheTrueProgrammer(string name) : base(25) => Name = name;
    public override IAttack StandardAttack { get; } = new Punch();
}

public class Punch : IAttack
{
    public string Name => "PUNCH";
    public AttackData Create() => new AttackData(1);
}

public class TheUncodedOne : Character
{
    public override string Name => "THE UNCODED ONE";
    public TheUncodedOne() : base(15) { }
    public override IAttack StandardAttack { get; } = new Unraveling();
}

public class Unraveling : IAttack
{
    private static readonly Random _random = new Random();
    public string Name => "UNRAVELING";
    public AttackData Create() => new AttackData(_random.Next(3));
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
