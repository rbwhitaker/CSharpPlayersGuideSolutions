Console.WriteLine("The following items are available:");
Console.WriteLine("1 - Rope");
Console.WriteLine("2 - Torches");
Console.WriteLine("3 - Climbing Equipment");
Console.WriteLine("4 - Clean Water");
Console.WriteLine("5 - Machete");
Console.WriteLine("6 - Canoe");
Console.WriteLine("7 - Food Supplies");
Console.Write("What number do you want to see the price of? ");
int itemNumber = Convert.ToInt32(Console.ReadLine());

string item = itemNumber switch
{
    1 => "Rope",
    2 => "Torches",
    3 => "Climbing Equipment",
    4 => "Clean Water",
    5 => "Machete",
    6 => "Canoe",
    7 => "Food Supplies"
};

// Depending on which version of the book you have, these prices might
// be slightly different than what you have. I tweaked them here to
// sidestep the issue of handling fractional values or truncation
// from integer division.
//
// However, if your solution just did plain old integer division
// and left the prices as they were in your version of the book,
// or if you changed over to floating-point division to take advantage
// of fractional values, either of those solutions are just fine.
//
// The point of this challenge is to use switches and to get
// experience modifying a program with new features. The division
// thing is really just a diversion. (Which is why I opted to sidestep
// it here by making the numbers all divisible by two.)
int price = item switch
{
    "Rope" => 10,
    "Torches" => 16,
    "Climbing Equipment" => 24,
    "Clean Water" => 2,
    "Machete" => 20,
    "Canoe" => 200,
    "Food Supplies" => 2
};

Console.Write("What is your name? ");
string name = Console.ReadLine();

if (name == "RB") price /= 2;

Console.WriteLine($"{item} costs {price} gold.");
