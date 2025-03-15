(Form, Ingredient, Seasoning) soup = (Form.Stew, Ingredient.Mushrooms, Seasoning.Garlic);
Console.WriteLine($"{soup.Item3} {soup.Item2} {soup.Item1}"); // Garlic Mushrooms Stew.

public enum Form {  Soup, Stew, Curry }
public enum Ingredient { Mushrooms, Chicken, Carrots, Potatoes }
public enum Seasoning { Garlic, Cayenne, Ginger }