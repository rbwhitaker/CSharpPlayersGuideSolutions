using System;

public class Skelomancer : Character
{
    public override string Name => "SKELOMANCER";
    public Skelomancer() : base(4) => Ability = new Summon();
}

public class Summon : IAbility
{
    private static Random _random = new Random();
    public string Name => "SUMMON";

    public void Use(Battle battle, Character user)
    {
        if (_random.Next(2) != 0)
        {
            ColoredConsole.WriteLine($"{user.Name} used {Name}. It failed.", ConsoleColor.Yellow);
            return;
        }

        Skeleton toAdd = new Skeleton();
        ColoredConsole.WriteLine($"{user.Name} used {Name} and summoned a new {toAdd.Name}!", ConsoleColor.Yellow);
        battle.GetPartyFor(user).Characters.Add(toAdd);
    }
}