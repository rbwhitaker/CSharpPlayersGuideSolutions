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
Party heroes = new Party(player1);
heroes.Characters.Add(new TheTrueProgrammer(name));
heroes.Characters.Add(new VinFletcher());
heroes.Items.Add(new HealthPotion());
heroes.Items.Add(new HealthPotion());
heroes.Items.Add(new HealthPotion());

// Create all the monster parties now. (We could create one at a time, being able to just iterate over an array was too convenient in this case.)
List<Party> monsterParties = new List<Party> { CreateMonsterParty1(player2), CreateMonsterParty2(player2), CreateMonsterParty3(player2), CreateMonsterParty4(player2) };

// Loop through all the battles (we're tentatively assuming the hero is going to win them all...
for (int battleNumber = 0; battleNumber < monsterParties.Count; battleNumber++)
{
    // Create the battle between the two and run it to completion.
    Party monsters = monsterParties[battleNumber];
    Battle battle = new Battle(heroes, monsters);
    battle.Run();

    // If our assumption was wrong and the heroes all died off, then end the game.
    if (heroes.Characters.Count == 0) break;
}

// Display who won.
if (heroes.Characters.Count > 0) ColoredConsole.WriteLine("You have defeated the Uncoded One's forces! You have won the battle!", ConsoleColor.Green);
else ColoredConsole.WriteLine("You have been defeated. The Uncoded One has won.", ConsoleColor.Red);


// Create the monster party for Battle 1
Party CreateMonsterParty1(IPlayer controllingPlayer)
{
    Party monsters = new Party(controllingPlayer);
    monsters.Characters.Add(new Skeleton { EquippedGear = new Dagger() });
    return monsters;
}

// Create the monster party for Battle 1
Party CreateMonsterParty2(IPlayer controllingPlayer)
{
    Party monsters = new Party(controllingPlayer);
    monsters.Characters.Add(new Skeleton());
    monsters.Characters.Add(new Skeleton());
    monsters.Gear.Add(new Dagger());
    monsters.Gear.Add(new Dagger());
    return monsters;
}

// Create the monsters for Battle #3.
Party CreateMonsterParty3(IPlayer controllingPlayer)
{
    Party monsters = new Party(controllingPlayer);
    monsters.Characters.Add(new StoneAmarok());
    monsters.Characters.Add(new StoneAmarok());
    monsters.Items.Add(new HealthPotion());
    monsters.Items.Add(new HealthPotion());
    return monsters;
}

// Create the monster party for Battle 4
Party CreateMonsterParty4(IPlayer controllingPlayer)
{
    Party monsters = new Party(controllingPlayer);
    monsters.Characters.Add(new TheUncodedOne());
    return monsters;
}