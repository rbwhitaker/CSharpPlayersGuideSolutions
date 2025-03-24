Console.Write("What is your name? ");
string? name = Console.ReadLine();

int score = 0;

if (File.Exists(name + ".txt"))
{
    score = Convert.ToInt32(File.ReadAllText(name + ".txt"));
    Console.WriteLine($"Welcome back, {name}. Your score will resume at {score}.");
}

while (true)
{
    ConsoleKey key = Console.ReadKey().Key;
    if (key == ConsoleKey.Escape)
        break;

    score++;
    Console.WriteLine(score);
}

File.WriteAllText(name + ".txt", score.ToString());