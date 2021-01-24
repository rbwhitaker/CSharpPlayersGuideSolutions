using System;

Pack pack = new Pack(10, 20, 30);

while (true)
{
    Console.WriteLine(pack);
    Console.WriteLine($"Pack is currently at {pack.CurrentCount}/{pack.MaxCount} items, {pack.CurrentWeight}/{pack.MaxWeight} weight, and {pack.CurrentVolume}/{pack.MaxVolume} volume.");

    Console.WriteLine("What do you want to add?");
    Console.WriteLine("1 - Arrow");
    Console.WriteLine("2 - Bow");
    Console.WriteLine("3 - Rope");
    Console.WriteLine("4 - Some Water");
    Console.WriteLine("5 - Lots of Water");
    Console.WriteLine("6 - Food");
    Console.WriteLine("7 - Sword");
    int choice = Convert.ToInt32(Console.ReadLine());

    InventoryItem newItem = choice switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(2),
        5 => new Water(10),
        6 => new Food(),
        7 => new Sword()
    };

    if (!pack.Add(newItem))
        Console.WriteLine("Could not add this to the pack.");
}

public class Pack
{
    public int MaxCount { get; }
    public float MaxVolume { get; }
    public float MaxWeight { get; }

    private InventoryItem[] _items;

    public int CurrentCount { get; private set; }
    public float CurrentVolume { get; private set; }
    public float CurrentWeight { get; private set; }

    public Pack(int maxCount, float maxVolume, float maxWeight)
    {
        MaxCount = maxCount;
        MaxVolume = maxVolume;
        MaxWeight = maxWeight;

        _items = new InventoryItem[maxCount];
    }

    public bool Add(InventoryItem item)
    {
        if (CurrentCount >= MaxCount) return false;
        if (CurrentVolume + item.Volume > MaxVolume) return false;
        if (CurrentWeight + item.Weight > MaxWeight) return false;

        _items[CurrentCount] = item;
        CurrentCount++;
        CurrentVolume += item.Volume;
        CurrentWeight += item.Weight;
        return true;
    }

    public override string ToString()
    {
        string contents = "Pack containing ";
        if (CurrentCount == 0) contents += "Nothing";

        for (int itemNumber = 0; itemNumber < CurrentCount; itemNumber++)
            contents += _items[itemNumber].ToString() + " ";

        return contents;
    }
}

public abstract class InventoryItem
{
    public virtual float Weight { get; }
    public float Volume { get; }

    protected InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

public class Arrow : InventoryItem
{
    public Arrow() : base(0.1f, 0.05f) { }

    public override string ToString() => "Arrow";
}

public class Bow : InventoryItem
{
    public Bow() : base(1, 4) { }

    public override string ToString() => "Bow";
}

public class Rope : InventoryItem
{
    public Rope() : base(1, 1.5f) { }

    public override string ToString() => "Rope";
}

public class Water : InventoryItem
{
    public Water(float volume) : base(float.NaN, volume) { } // Since we're overriding weight, it doesn't matter what we pass down for weight.

    public override float Weight => Volume * 1.5f;

    public override string ToString() => "Water";
}

public class Food : InventoryItem
{
    public Food() : base(1, 0.5f) { }

    public override string ToString() => "Food";
}

public class Sword : InventoryItem
{
    public Sword() : base(5, 3) { }

    public override string ToString() => "Sword";
}

// Answer this question: InventoryItem is currently not abstract. Would it be better if it were, and why or why not?
//
// I think it should be, and in fact, I made it so. InventoryItem serves as a base, but on its own, it is a meaningless
// concept. I don't think it should be possible to make a `new InventoryItem()` without it being one of the more
// specialized types.