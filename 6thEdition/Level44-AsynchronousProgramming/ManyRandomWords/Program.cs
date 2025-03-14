while (true)
{
    Console.Write("Enter a word to randomly regenerate: ");
    string? word = Console.ReadLine();
    HandleWord(word);
}

async Task HandleWord(string? word)
{
    DateTime start = DateTime.Now;
    int attempts = await RandomlyRecreateAsync(word);
    Console.WriteLine($"The word {word} took {attempts} attempts.");
    TimeSpan elapsed = DateTime.Now - start;
    Console.WriteLine(elapsed);
}

int RandomlyRecreate(string? word)
{
    if (word == null) return 0;

    Random random = new Random();

    string generated;
    int attempts = 0;
    do
    {
        attempts++;
        generated = "";
        for (int letter = 0; letter < word.Length; letter++)
            generated += (char)('a' + random.Next(26));
    } while (generated != word);

    return attempts;
}

Task<int> RandomlyRecreateAsync(string? word)
{
    return Task.Run(() => RandomlyRecreate(word));
}
