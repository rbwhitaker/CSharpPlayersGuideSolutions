using System;

// Get the name from the player. I've called ToUpper on this because most elements in the game use ALL CAPS to refer to proper nouns. This keeps it consistent.
string name = ColoredConsole.Prompt("What is your name?").ToUpper();

// Let the user pick a gameplay mode and then create players based on the choice they made.
Console.WriteLine("Game Mode Selection:");
Console.WriteLine("1 - Human vs. Computer");
Console.WriteLine("2 - Computer vs. Computer");
Console.WriteLine("3 - Human vs. Human");
string choice = ColoredConsole.Prompt("What mode do you want to use?");

IPlayer player1, player2;

if (choice == "1") { player1 = new ConsolePlayer(); player2 = new ComputerPlayer(); }
else if (choice == "2") { player1 = new ComputerPlayer(); player2 = new ComputerPlayer(); }
else { player1 = new ConsolePlayer(); player2 = new ConsolePlayer(); }

// Construct the hero party. Put Player 1 in charge of this party.
Party heroes = new Party { Player = player1 };
heroes.Characters.Add(new TheTrueProgrammer(name));

// Create all the monster parties now. (We could create one at a time, being able to just iterate over an array was too convenient in this case.)
Party[] monsterParties = new Party[] { CreateMonstersForBattle1(), CreateMonstersForBattle2(), CreateMonstersForBattle3() };

// Loop through all the battles (we're tentatively assuming the hero is going to win them all...
for (int battleNumber = 0; battleNumber < monsterParties.Length; battleNumber++)
{
    // Get the party of monsters for the current battle.
    Party monsters = monsterParties[battleNumber];
    monsters.Player = player2; // Put Player 2 in charge of this party.

    // Create the battle between the two and run it to completion.
    Battle battle = new Battle(heroes, monsters);
    battle.Run();

    // If our assumption was wrong and the heroes all died off, then end the game.
    if (heroes.Characters.Count == 0) break;
}

// Display who won.
if (heroes.Characters.Count > 0) ColoredConsole.WriteLine("You have defeated the Uncoded One's forces! You have won the battle!", ConsoleColor.Green);
else ColoredConsole.WriteLine("You have been defeated. The Uncoded One has won.", ConsoleColor.Red);

// Create the monsters for Battle #1.
Party CreateMonstersForBattle1()
{
    Party monsters = new Party();
    monsters.Characters.Add(new Skeleton());
    return monsters;
}

// Create the monsters for Battle #2.
Party CreateMonstersForBattle2()
{
    Party monsters = new Party();
    monsters.Characters.Add(new Skeleton());
    monsters.Characters.Add(new Skeleton());
    return monsters;
}

// Create the monsters for Battle #3.
Party CreateMonstersForBattle3()
{
    Party monsters = new Party();
    monsters.Characters.Add(new TheUncodedOne());
    return monsters;
}