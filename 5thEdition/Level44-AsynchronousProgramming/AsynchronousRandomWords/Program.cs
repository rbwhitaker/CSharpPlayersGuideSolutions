Console.Write("Enter a word to randomly regenerate: ");
string? word = Console.ReadLine();

DateTime start = DateTime.Now;
int attempts = await RandomlyRecreateAsync(word);
Console.WriteLine(attempts);
TimeSpan elapsed = DateTime.Now - start;
Console.WriteLine(elapsed);

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
