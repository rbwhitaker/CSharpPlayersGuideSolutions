Pack pack = new Pack(10, 20, 30);

while (true)
{
    Console.WriteLine(pack);
    Console.WriteLine($"Pack is currently at {pack.CurrentCount}/{pack.MaxCount} items, {pack.CurrentWeight}/{pack.MaxWeight} weight, and {pack.CurrentVolume}/{pack.MaxVolume} volume.");

    Console.WriteLine("What do you want to add?");
    Console.WriteLine("1 - Arrow");
    Console.WriteLine("2 - Bow");
    Console.WriteLine("3 - Rope");
    Console.WriteLine("4 - Water");
    Console.WriteLine("5 - Food");
    Console.WriteLine("6 - Sword");
    int choice = Convert.ToInt32(Console.ReadLine());

    InventoryItem newItem = choice switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new Food(),
        6 => new Sword()
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

public class InventoryItem
{
    public float Weight { get; }
    public float Volume { get; }

    public InventoryItem(float weight, float volume)
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
    public Water() : base(2, 3) { }

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

// Answer this question: We could have made a different method or property (for example
// `Description`) instead of overriding `ToString`. Which do you prefer and why?
//
// This is a very opinion-based question, and there isn't a right answer. I've done
// both in different circumstances. One catch with `ToString` is that it is used all
// over the place. If there isn't a single, definitive string representation for something,
// it might be better to make another property instead. But as I said, it is used
// all over the place. If you override `ToString`, then you can do something as simple
// as `Console.WriteLine(new Sword());` and it will display that text. If you made a
// `Description` property, you wouldn't get that benefit. You'd have to do
// `Console.WriteLine(new Sword().Description);` instead.
//
// For this particular challenge, I like overriding `ToString`. It keeps the code the
// simplest. It doesn't demand making a whole other property. But had the code been more
// complicated, and had there been a need for multiple text representations of the item
// (say, a title and a description) then I might have chosen to make `Title` and
// `Description` properties instead.