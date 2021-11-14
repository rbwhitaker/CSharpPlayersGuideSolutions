RecentNumbers recentNumbers = new RecentNumbers { MostRecent = -1, SecondMostRecent = -2 };
Thread generatingThread = new Thread(GenerateNumbers);
generatingThread.Start(recentNumbers);

while (true)
{
    Console.ReadKey(false);

    bool isDuplicate;
    lock(recentNumbers)
        isDuplicate = recentNumbers.MostRecent == recentNumbers.SecondMostRecent;
    
    if(isDuplicate) Console.WriteLine("You found a duplicate!");
    else Console.WriteLine("That is not a duplicate.");
}

void GenerateNumbers(object? o)
{
    if (o == null || o is not RecentNumbers) return; // Shouldn't ever happen, but worth checking anyway.

    RecentNumbers recentNumbers = (RecentNumbers)o;
    Random random = new Random();
    while (true)
    {
        int nextNumber = random.Next(10);

        lock (recentNumbers)
        {
            recentNumbers.SecondMostRecent = recentNumbers.MostRecent;
            recentNumbers.MostRecent = nextNumber;
        }

        Console.WriteLine(nextNumber);
        Thread.Sleep(1000);
    }
}

public class RecentNumbers
{
    public int MostRecent { get; set; }
    public int SecondMostRecent { get; set; }
}