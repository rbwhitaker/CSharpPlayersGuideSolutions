using System.Collections.Generic;

public class Party
{
    public List<Character> Characters { get; } = new List<Character>();
    public bool HasBeenDefeated => Characters.Count == 0;
    public Inventory SharedInventory { get; } = new Inventory();
    public IPlayer Player { get; }

    public Party(IPlayer player) => Player = player;
}

