using Humanizer;

Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddHours(30).Humanize()}");
Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddSeconds(30).Humanize()}");
Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddYears(2).Humanize()}");
Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddMonths(1).Humanize()}");