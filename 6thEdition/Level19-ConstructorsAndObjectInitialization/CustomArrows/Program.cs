while (true)
{
    Console.WriteLine("Fletching Type (1=Plastic, 2=TurkeyFeathers, 3=GooseFeathers: ");
    int input = Convert.ToInt32(Console.ReadLine());
    FletchingType fletchingType = input switch
    {
        1 => FletchingType.Plastic,
        2 => FletchingType.TurkeyFeathers,
        3 => FletchingType.GooseFeathers
    };

    Console.WriteLine("Arrowhead Type (1=Steel, 2=Wood, 3=Obsidian: ");
    input = Convert.ToInt32(Console.ReadLine());
    ArrowheadType arrowheadType = input switch
    {
        1 => ArrowheadType.Steel,
        2 => ArrowheadType.Wood,
        3 => ArrowheadType.Obsidian
    };

    Console.WriteLine("Length (60-100): ");
    float length = Convert.ToSingle(Console.ReadLine());

    Arrow customArrow = new Arrow(arrowheadType, fletchingType, length);
    Console.WriteLine($"Custom Arrow Cost: {customArrow.GetCost()} gold.");
}

public class Arrow
{
    public ArrowheadType ArrowheadType;
    public FletchingType FletchingType;
    public float Length;

    public Arrow(ArrowheadType arrowheadType, FletchingType fletchingType, float length)
    {
        ArrowheadType = arrowheadType;
        FletchingType = fletchingType;
        Length = length;
    }

    public float GetCost()
    {
        float cost = 0.0f;

        cost += ArrowheadType switch
        {
            ArrowheadType.Steel => 10,
            ArrowheadType.Wood => 3,
            ArrowheadType.Obsidian => 5
        };

        cost += FletchingType switch
        {
            FletchingType.Plastic => 10,
            FletchingType.TurkeyFeathers => 5,
            FletchingType.GooseFeathers => 3
        };

        cost += 0.05f * Length;

        return cost;
    }
}

public enum ArrowheadType { Steel, Wood, Obsidian }
public enum FletchingType { Plastic, TurkeyFeathers, GooseFeathers }