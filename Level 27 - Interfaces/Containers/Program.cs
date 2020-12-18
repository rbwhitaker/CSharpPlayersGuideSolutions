using System;

Pack pack = new Pack(10, 20, 30);
Bag bag1 = new Bag(3, 5, 5);
bag1.Add(new Bow());
bag1.Add(new Arrow());
bag1.Add(new Arrow());

Bag bag2 = new Bag(3, 10, 10);
bag2.Add(new Sword());
bag2.Add(new Water(0.5f));

pack.Add(bag1);
pack.Add(bag2);

Console.WriteLine(pack);

public interface IContainer
{
    int MaxCount { get; }
    float MaxVolume { get; }
    float MaxWeight { get; }
    int CurrentCount { get; }
    float CurrentVolume { get; }
    float CurrentWeight { get; }
    bool Add(IInventoryItem newItem);
}

public class Bag : Container, IInventoryItem
{
    public float Weight => CurrentWeight;

    public float Volume => CurrentVolume;

    public Bag(int maxCount, float maxVolume, float maxWeight) : base(maxCount, maxVolume, maxWeight) { }
}

public abstract class Container : IContainer
{
    public int MaxCount { get; }
    public float MaxVolume { get; }
    public float MaxWeight { get; }

    protected IInventoryItem[] _items;

    public int CurrentCount { get; private set; }
    public float CurrentVolume { get; private set; }
    public float CurrentWeight { get; private set; }

    public Container(int maxCount, float maxVolume, float maxWeight)
    {
        MaxCount = maxCount;
        MaxVolume = maxVolume;
        MaxWeight = maxWeight;

        _items = new IInventoryItem[maxCount];
    }

    public bool Add(IInventoryItem item)
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
}

public class Pack : Container
{

    public Pack(int maxCount, float maxVolume, float maxWeight) : base(maxCount, maxVolume, maxWeight) { }

    public override string ToString()
    {
        string contents = "Pack containing ";
        if (CurrentCount == 0) contents += "Nothing";

        for (int itemNumber = 0; itemNumber < CurrentCount; itemNumber++)
            contents += _items[itemNumber].ToString() + " ";

        return contents;
    }
}

public interface IInventoryItem
{
    float Weight { get; }
    float Volume { get; }
}

public abstract class InventoryItem : IInventoryItem
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