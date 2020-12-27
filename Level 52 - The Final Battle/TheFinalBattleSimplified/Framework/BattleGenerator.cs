// Does the job of building parties (both heroes and monsters) for battles.
public class BattleGenerator
{
    // The number of levels 
    public int TotalLevels => 7;

    // Creates the initial party for heroes.
    public Party CreateHeroParty(string playerName, IPlayer controllingPlayer)
    {
        Party heroes = new Party(controllingPlayer);
        heroes.Characters.Add(new PlayerCharacter(playerName));
        heroes.Characters.Add(new VinFletcher());
        heroes.Characters.Add(new MylaraAndSkorin());
        heroes.SharedInventory.Items.Add(new HealthPotion());
        heroes.SharedInventory.Items.Add(new HealthPotion());
        heroes.SharedInventory.Items.Add(new HealthPotion());
        return heroes;
    }

    // Creates a party for the monsters in any given level (1-based numbering).
    public Party CreateMonsterPartyForLevel(IPlayer controllingPlayer, int level)
    {
        return level switch
        {
            1 => CreateLevel1(controllingPlayer),
            2 => CreateLevel2(controllingPlayer),
            3 => CreateLevel3(controllingPlayer),
            4 => CreateLevel4(controllingPlayer),
            5 => CreateLevel5(controllingPlayer),
            6 => CreateLevel6(controllingPlayer),
            7 => CreateLevel7(controllingPlayer),
        };
    }

    private static Party CreateLevel1(IPlayer controllingPlayer)
    {
        Party party = new Party(controllingPlayer);
        party.Characters.Add(new Skeleton());
        party.SharedInventory.Items.Add(new HealthPotion());
        return party;
    }

    private static Party CreateLevel2(IPlayer controllingPlayer)
    {
        Party party = new Party(controllingPlayer);
        party.Characters.Add(new Skeleton());
        party.Characters.Add(new Skeleton());
        return party;
    }

    private static Party CreateLevel3(IPlayer controllingPlayer)
    {
        Party party = new Party(controllingPlayer);
        party.Characters.Add(new HandOfTheUncodedOne());
        party.SharedInventory.Items.Add(new HealthPotion());
        return party;
    }

    private static Party CreateLevel4(IPlayer controllingPlayer)
    {
        Party party = new Party(controllingPlayer);
        party.Characters.Add(new StoneAmarok());
        party.Characters.Add(new StoneAmarok());
        party.Characters.Add(new StoneAmarok());
        party.SharedInventory.Items.Add(new HealthPotion());
        return party;
    }

    private static Party CreateLevel5(IPlayer controllingPlayer)
    {
        Party party = new Party(controllingPlayer);
        party.Characters.Add(new Skeleton());
        party.Characters.Add(new Skelomancer());
        party.SharedInventory.Items.Add(new HealthPotion());
        return party;
    }

    private static Party CreateLevel6(IPlayer controllingPlayer)
    {
        Party party = new Party(controllingPlayer);
        party.Characters.Add(new Skeleton());
        party.Characters.Add(new Skeleton());
        party.SharedInventory.Items.Add(new HealthPotion());
        party.SharedInventory.Items.Add(new HealthPotion());
        return party;
    }

    private static Party CreateLevel7(IPlayer controllingPlayer)
    {
        Party party = new Party(controllingPlayer);
        party.Characters.Add(new Skeleton());
        party.Characters.Add(new Skeleton());
        party.Characters.Add(new Skeleton());
        party.Characters.Add(new Skeleton());
        party.Characters.Add(new TheUncodedOne());
        party.SharedInventory.Items.Add(new HealthPotion());
        party.SharedInventory.Items.Add(new HealthPotion());
        return party;
    }
}
