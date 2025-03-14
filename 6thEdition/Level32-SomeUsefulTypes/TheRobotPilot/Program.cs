// Setup the game.
int cityHealth = 15;
int manticoreHealth = 10;
int round = 1;

// Randomly choose the starting distance for the Manticore.
Random random = new Random();
int range = random.Next(100);

// Run the game until the city is destroyed or the Manticore is destroyed.
while (cityHealth > 0 && manticoreHealth > 0)
{
    // Display the status for the round.
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("-----------------------------------------------------------");
    DisplayStatus(round, cityHealth, manticoreHealth);

    // Display the amount of damage expected on a hit.
    int damage = DamageForRound(round);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"The cannon is expected to deal {damage} damage this round.");

    // Get a number from the player.
    Console.ForegroundColor = ConsoleColor.White;
    int targetRange = AskForNumber("Enter desired cannon range:");

    // Display the outcome of the number.
    Console.ForegroundColor = ConsoleColor.Magenta;
    DisplayOverOrUnder(targetRange, range);

    // Deal damage to the Manticore if it was a hit.
    if (targetRange == range) manticoreHealth -= damage;

    // Deal damage to the city if the Manticore is still alive.
    if (manticoreHealth > 0) cityHealth--;

    // Go on to the next round.
    round++;
}

// Display the outcome of the game.
bool won = cityHealth > 0;
DisplayWinOrLose(won);

// ------------------------------- METHODS --------------------------------

// Displays the result of the game.
void DisplayWinOrLose(bool won)
{
    if (won)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The city has been destroyed. The Manticore and the Uncoded One have won.");
    }
}

// Tells the player if they fell short, overshot, or hit their target.
void DisplayOverOrUnder(int targetRange, int range)
{
    if (targetRange < range) Console.WriteLine("That round FELL SHORT of the target.");
    else if (targetRange > range) Console.WriteLine("That round OVERSHOT the target.");
    else Console.WriteLine("That round was a DIRECT HIT!");
}

// Displays the status of the game, including the round number, and health of city and Manticore.
void DisplayStatus(int round, int cityHealth, int manticoreHealth) =>
    Console.WriteLine($"STATUS: Round: {round}  City: {cityHealth}/15  Manticore: {manticoreHealth}/10");

// Computes how much damage will be done depending on the current round.
// A multiple of 3 is a Fire blast. A multiple of 5 is an Electric blast.
// A multiple of both 3 and 5 is an extremely powerful combined blast.
// Anything else is a normal round.
int DamageForRound(int roundNumber)
{
    if (roundNumber % 5 == 0 && roundNumber % 3 == 0) return 10; // Combined Electric and Fire
    else if (roundNumber % 5 == 0) return 3; // Electric
    else if (roundNumber % 3 == 0) return 3; // Fire
    return 1; // Normal.
}

// Gets a number from the user, asking the prompt supplied by 'text'.
int AskForNumber(string text)
{
    Console.Write(text + " ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}