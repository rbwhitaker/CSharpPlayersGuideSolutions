Arrow arrow = GetArrow();
Console.WriteLine($"That arrow costs {arrow.GetCost()} gold.");



Arrow GetArrow()
{
    Arrowhead arrowhead = GetArrowheadType();
    Fletching fletching = GetFletchingType();
    float length = GetLength();

    return new Arrow(arrowhead, fletching, length);
}

Arrowhead GetArrowheadType()
{
    Console.Write("Arrowhead type (steel, wood, obsidian): ");
    string input = Console.ReadLine();
    return input switch
    {
        "steel" => Arrowhead.Steel,
        "wood" => Arrowhead.Wood,
        "obsidian" => Arrowhead.Obsidian
    };
}

Fletching GetFletchingType()
{
    Console.Write("Fletching type (plastic, turkey feather, goose feather): ");
    string input = Console.ReadLine();
    return input switch
    {
        "plastic" => Fletching.Plastic,
        "turkey feather" => Fletching.TurkeyFeathers,
        "goose feather" => Fletching.GooseFeathers
    };
}

float GetLength()
{
    float length = 0;

    while (length < 60 || length > 100)
    {
        Console.Write("Arrow length (between 60 and 100): ");
        length = Convert.ToSingle(Console.ReadLine());
    }

    return length;
}

public class Arrow
{
    private Arrowhead _arrowhead;
    private Fletching _fletching;
    private float _length;

    public Arrowhead GetArrowhead() => _arrowhead;
    public Fletching GetFletching() => _fletching;
    public float GetLength() => _length;

    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;
    }

    public float GetCost()
    {
        float arrowheadCost = _arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5
        };

        float fletchingCost = _fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3
        };

        float shaftCost = 0.05f * _length;

        return arrowheadCost + fletchingCost + shaftCost;
    }
}

public enum Arrowhead { Steel, Wood, Obsidian }
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }