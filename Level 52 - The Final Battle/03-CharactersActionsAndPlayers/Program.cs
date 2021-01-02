using System;
using System.Collections.Generic;
using System.Threading;

string name = ColoredConsole.Prompt("What is your name?").ToUpper();

Party heroes = new Party { Player = new ComputerPlayer() };
heroes.Characters.Add(new TheTrueProgrammer(name));

Party monsters = new Party { Player = new ComputerPlayer() };
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

public class ComputerPlayer : IPlayer
{
    public IAction ChooseAction(Battle battle, Character character)
    {
        Thread.Sleep(500);
        return new DoNothingAction();
    }
}

public class Party
{
    public IPlayer Player { get; set; }
    public List<Character> Characters { get; } = new List<Character>();
}

public abstract class Character
{
    public abstract string Name { get; }
}

public class Skeleton : Character
{
    public override string Name => "SKELETON";
}

public class TheTrueProgrammer : Character
{
    public override string Name { get; }

    public TheTrueProgrammer(string name) => Name = name;
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
        string input = Console.ReadLine();
        Console.ForegroundColor = previousColor;
        return input;
    }
}