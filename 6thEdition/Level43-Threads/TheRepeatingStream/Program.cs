RecentNumbers recentNumbers = new RecentNumbers();
Thread generatingThread = new Thread(GenerateNumbers);
generatingThread.Start(recentNumbers);

while (true)
{
    Console.ReadKey(false);

    bool isDuplicate = recentNumbers.IsDuplicate();
    
    if (isDuplicate) Console.WriteLine("You found a duplicate!");
    else Console.WriteLine("That is not a duplicate.");
}

void GenerateNumbers(object? o)
{
    if (o is not RecentNumbers recentNumbers) return; // Shouldn't ever happen, but worth checking anyway.

    Random random = new ();

    while (true)
    {
        int nextNumber = random.Next(10);

        recentNumbers.AddNextNumber(nextNumber);

        Console.WriteLine(nextNumber);
        Thread.Sleep(1000);
    }
}

public class RecentNumbers
{
    private int _current = -1;  // Initialize these two fields to two numbers
    private int _previous = -2; // that aren't equal. Doesn't matter what.
    private readonly Lock _lock = new();

    public bool IsDuplicate()
    {
        lock (_lock)
        {
            return _current == _previous;
        }
    }

    public void AddNextNumber(int nextNumber)
    {
        lock (_lock)
        {
            _previous = _current;
            _current = nextNumber;
        }
    }
}