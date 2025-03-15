(Form Form, Ingredient Ingredient, Seasoning Seasoning) soup = (Form.Stew, Ingredient.Mushrooms, Seasoning.Garlic);
Console.WriteLine($"{soup.Seasoning} {soup.Ingredient} {soup.Form}"); // Garlic Mushrooms Stew.

public enum Form { Soup, Stew, Curry }
public enum Ingredient { Mushrooms, Chicken, Carrots, Potatoes }
public enum Seasoning { Garlic, Cayenne, Ginger }