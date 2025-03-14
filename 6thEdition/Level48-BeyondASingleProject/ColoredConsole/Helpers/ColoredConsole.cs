namespace Helpers;

public static class ColoredConsole
{
    public static string? Prompt(string question)
    {
        Console.Write(question + " ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        return Console.ReadLine();
    }

    public static void Write(string? text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
    }

    public static void WriteLine(string? text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }
}