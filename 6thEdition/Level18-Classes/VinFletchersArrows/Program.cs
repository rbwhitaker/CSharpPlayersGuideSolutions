﻿Arrow arrow = new Arrow();

arrow.Length = 75;
arrow.FletchingType = FletchingType.TurkeyFeathers;
arrow.ArrowheadType = ArrowheadType.Steel;

Console.WriteLine(arrow.GetCost());

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