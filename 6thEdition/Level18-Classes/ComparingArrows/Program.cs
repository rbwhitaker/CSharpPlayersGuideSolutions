Arrow practiceArrow = new Arrow();
practiceArrow.Length = 75;
practiceArrow.FletchingType = FletchingType.GooseFeathers;
practiceArrow.ArrowheadType = ArrowheadType.Wood;

Arrow marksmanArrow = new Arrow();
marksmanArrow.Length = 65;
marksmanArrow.FletchingType = FletchingType.GooseFeathers;
marksmanArrow.ArrowheadType = ArrowheadType.Steel;

Arrow eliteArrow = new Arrow();
eliteArrow.Length = 95;
eliteArrow.FletchingType = FletchingType.Plastic;
eliteArrow.ArrowheadType = ArrowheadType.Steel;

Console.WriteLine("Practice: " + practiceArrow.GetCost());
Console.WriteLine("Marksman: " + marksmanArrow.GetCost());
Console.WriteLine("Elite:    " + eliteArrow.GetCost());

public class Arrow
{
    public ArrowheadType ArrowheadType;
    public FletchingType FletchingType;
    public float Length;

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