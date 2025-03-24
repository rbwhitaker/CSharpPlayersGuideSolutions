Arrow practiceArrow = new Arrow(ArrowheadType.Wood, FletchingType.GooseFeathers, 75);
Arrow marksmanArrow = new Arrow(ArrowheadType.Steel, FletchingType.GooseFeathers, 65);
Arrow eliteArrow = new Arrow(ArrowheadType.Steel, FletchingType.Plastic, 95);

Console.WriteLine("Practice: " + practiceArrow.GetCost());
Console.WriteLine("Marksman: " + marksmanArrow.GetCost());
Console.WriteLine("Elite:    " + eliteArrow.GetCost());

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