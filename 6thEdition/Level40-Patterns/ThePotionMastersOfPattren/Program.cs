PotionType potion = PotionType.Water;

while (true)
{
    Console.WriteLine($"Current Potion: {potion}");

    Console.WriteLine("Do you want to add more ingredients? ");
    string? input = Console.ReadLine();
    if (input == "no") break;

    Console.WriteLine("Available ingredients: stardust, snake venom, dragon breath, shadow glass, eyeshine gem");
    
    Ingredients ingredient = Console.ReadLine() switch
    {
        "stardust" => Ingredients.Stardust,
        "snake venom" => Ingredients.SnakeVenom,
        "dragon breath" => Ingredients.DragonBreath,
        "shadow glass" => Ingredients.ShadowGlass,
        "eyeshine gem" => Ingredients.EyeshineGem
    };

    potion = (ingredient, potion) switch
    {
        (Ingredients.Stardust, PotionType.Water) => PotionType.Elixir,               // Adding stardust to water turns it into an elixir.
        (Ingredients.SnakeVenom, PotionType.Elixir) => PotionType.Poison,            // Adding snake venom to an elixir turns it into a poison potion.
        (Ingredients.DragonBreath, PotionType.Elixir) => PotionType.Flying,          // Adding dragon breath to an elixir turns it into a flying potion.
        (Ingredients.ShadowGlass, PotionType.Elixir) => PotionType.Invisibility,     // Adding shadow glass to an elixir turns it into an invisibility potion.
        (Ingredients.EyeshineGem, PotionType.Elixir) => PotionType.NightSight,       // Adding an eyeshine gem to an elixir turns it into a night sight potion.
        (Ingredients.ShadowGlass, PotionType.NightSight) => PotionType.CloudyBrew,   // Adding shadow glass to a night sight potion turns it into a cloudy brew.
        (Ingredients.EyeshineGem, PotionType.Invisibility) => PotionType.CloudyBrew, // Adding an eyeshine gem to an invisibility potion turns it into a cloudy brew.
        (Ingredients.Stardust, PotionType.CloudyBrew) => PotionType.Wraith,          // Adding stardust to a cloudy brew turns it into a wraith potion.
        (_, _) => PotionType.Ruined,                                                 // Anything else results in a ruined potion.
    };

    if (potion == PotionType.Ruined)
    {
        Console.WriteLine("Oh no! The potion is ruined! Lets start over.");
        potion = PotionType.Water;
    }
}


public enum Ingredients { Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem }
public enum PotionType { Water, Elixir, Poison, Flying, Invisibility, NightSight, CloudyBrew, Wraith, Ruined }