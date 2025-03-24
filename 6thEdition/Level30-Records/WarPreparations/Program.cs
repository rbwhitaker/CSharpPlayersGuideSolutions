Sword original = new Sword(Material.Iron, 5, 0.25f, Gemstone.None);
Sword fancy = original with { Material = Material.Binarium, Gemstone = Gemstone.Bitstone };
Sword ultralong = original with { Material = Material.Bronze, Length = 8, Gemstone = Gemstone.Emerald };

Console.WriteLine(original);
Console.WriteLine(fancy);
Console.WriteLine(ultralong);

public enum Material { Wood, Bronze, Iron, Steel, Binarium }
public enum Gemstone { Emerald, Amber, Saphhire, Diamond, Bitstone, None }
public record Sword(Material Material, float Length, float CrossguardWidth, Gemstone Gemstone);