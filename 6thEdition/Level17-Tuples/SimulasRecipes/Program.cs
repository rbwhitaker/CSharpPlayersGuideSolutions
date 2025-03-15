Console.Write("Pick a recipe number between 1 and 6: ");
int recipeNumber = Convert.ToInt32(Console.ReadLine());

(Form Form, Ingredient Ingredient, Seasoning Seasoning) soup;
soup = recipeNumber switch
{
    1 => (Form.Stew,  Ingredient.Mushrooms, Seasoning.Garlic),
    2 => (Form.Soup,  Ingredient.Carrots,   Seasoning.Cayenne),
    3 => (Form.Curry, Ingredient.Potatoes,  Seasoning.Ginger),
    4 => (Form.Curry, Ingredient.Chicken,   Seasoning.Cayenne),
    5 => (Form.Soup,  Ingredient.Chicken,   Seasoning.Garlic),
    6 => (Form.Stew,  Ingredient.Carrots,   Seasoning.Ginger)
};

Console.WriteLine($"{soup.Seasoning} {soup.Ingredient} {soup.Form}");

public enum Form { Soup, Stew, Curry }
public enum Ingredient { Mushrooms, Chicken, Carrots, Potatoes }
public enum Seasoning { Garlic, Cayenne, Ginger }