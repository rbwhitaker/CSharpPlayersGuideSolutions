using System;

// Represents the state of a single battle.
public class Battle
{
    // Indicates which number the battle is in the sequence.
    public int Number { get; }

    // The party of heroes.
    public Party Heroes { get; }

    // The party of monsters.
    public Party Monsters { get; }

    // Creates a new battle with its number and the two parties that constitute it.
    public Battle(int number, Party heroes, Party monsters)
    {
        Number = number;
        Heroes = heroes;
        Monsters = monsters;
    }

    // Finds the party that the character does *not* belong to--the party of the enemy.
    public Party GetOpposingParty(Character character) => Heroes.Characters.Contains(character) ? Monsters : Heroes;

    // Findsd the party that the character belongs to--their own party.
    public Party GetPartyFor(Character character) => Heroes.Characters.Contains(character) ? Heroes : Monsters;

    // Runs the battle until an outcome is known.
    public void Run()
    {
        // Until one team or another loses, keep running rounds.
        while (!IsBattleOver())
            RunRound();

        // When the outcome has been decided, transfer all items from the losing team's inventory over to the winning team.
        TransferInventoryToWinner();
    }

    // A battle is considered over if either of the parties report that they have been defeated.
    private bool IsBattleOver() => Heroes.HasBeenDefeated || Monsters.HasBeenDefeated;

    // Runs a single round, giving each character a turn.
    public void RunRound()
    {
        // Go through each party, heroes first.
        foreach (Party party in new[] { Heroes, Monsters })
        {
            // Give each player a chance to take their turn and pick an action.
            for (int index = 0; index < party.Characters.Count; index++)
            {
                // Show the status of the battle before each character's turn.
                Character character = party.Characters[index];
                BattleRenderer.Render(this, character);

                // Let the player pick an action.
                party.Player?.PickAction(this, character).Execute(this);

                // If the action ended the battle, end the battle without having
                // every remaining character take a turn. They won't have anything meaningful
                // to do anyway.
                if (IsBattleOver()) return;
            }
        }
    }

    // Allows the winning team to gain all inventory items that the losing team had.
    private void TransferInventoryToWinner()
    {
        if (Heroes.HasBeenDefeated) ColoredConsole.WriteLine("HEROES have been defeated. Their inventory has been looted by the MONSTERS.", ConsoleColor.Magenta);
        else ColoredConsole.WriteLine("MONSTERS have been defeated. Their inventory has been looted by the HEROES.", ConsoleColor.Magenta);

        Party winner = Heroes.HasBeenDefeated ? Monsters : Heroes;
        Party loser = Heroes.HasBeenDefeated ? Heroes : Monsters;
        loser.SharedInventory.TransferInventory(winner.SharedInventory);
    }
}