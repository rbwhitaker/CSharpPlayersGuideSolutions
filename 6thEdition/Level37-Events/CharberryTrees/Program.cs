CharberryTree tree = new CharberryTree();

Notifier announcer = new Notifier(tree);
Harvester harvester = new Harvester(tree);

while (true)
    tree.MaybeGrow();


public class Harvester
{
    private int _harvestCount;
    private CharberryTree _tree;
    public Harvester(CharberryTree tree)
    {
        _tree = tree;
        _tree.Ripened += OnTreeRipened;
    }

    private void OnTreeRipened()
    {
        _harvestCount++;
        _tree.Ripe = false;
        Console.WriteLine($"The tree has been harvested {_harvestCount} times.");
    }
}

public class Notifier
{
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnTreeRipened;
    }

    private void OnTreeRipened() => Console.WriteLine("The tree is ripe.");
}

public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }
    public event Action? Ripened;

    public void MaybeGrow()
    {
        // Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
}
