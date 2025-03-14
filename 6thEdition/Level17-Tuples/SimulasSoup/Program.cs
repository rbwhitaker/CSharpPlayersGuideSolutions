(SoupType type, MainIngredient ingredient, Seasoning seasoning) soup = GetSoup();
Console.WriteLine($"{soup.seasoning} {soup.ingredient} {soup.type}");

// Or this version, which skips the custom names:
//(SoupType, MainIngredient, Seasoning) soup = GetSoup();
//Console.WriteLine($"{soup.Item3} {soup.Item2} {soup.Item1}");

(SoupType, MainIngredient, Seasoning) GetSoup()
{
    SoupType type = GetSoupType();
    MainIngredient ingredient = GetMainIngredient();
    Seasoning seasoning = GetSeasoning();
    return (type, ingredient, seasoning);
}

SoupType GetSoupType()
{
    Console.Write("Soup type (soup, stew, gumbo): ");
    string input = Console.ReadLine();
    return input switch
    {
        "soup" => SoupType.Soup,
        "stew" => SoupType.Stew,
        "gumbo" => SoupType.Gumbo
    };
}

MainIngredient GetMainIngredient()
{
    Console.Write("Main ingredient (mushroom, chicken, carrot, potato): ");
    string input = Console.ReadLine();
    return input switch
    {
        "mushroom" => MainIngredient.Mushroom,
        "chicken" => MainIngredient.Chicken,
        "carrot" => MainIngredient.Carrot,
        "potato" => MainIngredient.Potato
    };
}

Seasoning GetSeasoning()
{
    Console.Write("Seasoning (spicy, salty, sweet): ");
    string input = Console.ReadLine();
    return input switch
    {
        "spicy" => Seasoning.Spicy,
        "salty" => Seasoning.Salty,
        "sweet" => Seasoning.Sweet,
    };
}

enum SoupType { Soup, Stew, Gumbo }
enum MainIngredient { Mushroom, Chicken, Carrot, Potato }
enum Seasoning { Spicy, Salty, Sweet }