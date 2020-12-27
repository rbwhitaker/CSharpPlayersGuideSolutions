using System;

Console.WriteLine("Pick a game mode:");
Console.WriteLine("1 - Human vs. Computer");
Console.WriteLine("2 - Computer vs. Computer");
Console.WriteLine("3 - Human vs. Human");

IPlayer player1;
IPlayer player2;
string mode = Console.ReadLine();
if (mode == "1") { player1 = new ConsolePlayer(); player2 = new SimpleComputerPlayer(); }
else if (mode == "2") { player1 = new SimpleComputerPlayer(); player2 = new SimpleComputerPlayer(); }
else { player1 = new ConsolePlayer(); player2 = new ConsolePlayer(); }

string playerName = "PLAYER";
if (mode == "1" || mode == "3")
{
    Console.Write("What is your name? ");
    playerName = Console.ReadLine().ToUpper();
}

BattleGenerator battleGenerator = new BattleGenerator();
Party heroes = battleGenerator.CreateHeroParty(playerName, player1);

for(int battleNumber = 1; battleNumber <= battleGenerator.TotalLevels; battleNumber++)
{
    Party monsters = battleGenerator.CreateMonsterPartyForLevel(player2, battleNumber);
    Battle battle = new Battle(battleNumber, heroes, monsters);
    battle.Run();
    if (heroes.HasBeenDefeated) break;
}

if (heroes.HasBeenDefeated) ColoredConsole.WriteLine("You have been defeated. The Uncoded One has won.", ConsoleColor.Red);
else ColoredConsole.WriteLine("You have defeated the Uncoded One! You have won the battle!", ConsoleColor.Green);