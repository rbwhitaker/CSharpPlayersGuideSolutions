Random random = new Random();

Console.WriteLine(random.NextDouble(100));
Console.WriteLine(random.NextString("Red", "Green", "Blue"));
Console.WriteLine(random.CoinFlip());
Console.WriteLine(random.CoinFlip(0.25));

// Extensions for the `Random` class, as opposed to arbitrary extensions.
public static class RandomExtensions
{
    public static double NextDouble(this Random random, double maximum) => random.NextDouble() * maximum;

    public static string NextString(this Random random, params string[] options) => options[random.Next(options.Length)];

    public static bool CoinFlip(this Random random, double probabilityOfHeads = 0.5) => random.NextDouble() < probabilityOfHeads;
}
