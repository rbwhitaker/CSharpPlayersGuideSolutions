using System;

Tree tree = new Tree();
Announcer announcer = new Announcer(tree);
Harvester harvester = new Harvester(tree);

while (true)
    tree.TryGrow();

public class Harvester
{
    private int _harvestCount;
    private Tree _tree;
    public Harvester(Tree tree)
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

public class Announcer
{
    public Announcer(Tree tree)
    {
        tree.Ripened += OnTreeRipened;
    }

    private void OnTreeRipened() => Console.WriteLine("The tree is ripe.");
}

public class Tree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }

    public void TryGrow()
    {
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
    }

    public event Action Ripened;
}