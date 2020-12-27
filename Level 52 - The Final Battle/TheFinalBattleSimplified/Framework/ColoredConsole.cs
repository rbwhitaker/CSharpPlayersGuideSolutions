using System;

// A collection of utility methods for displaying text on the console window using specific colors.
// Each of these save off the current color, change to the intended color, display text, and then when done,
// replace the console's color with what was previously saved off.
public static class ColoredConsole
{
    // Displays the given text in the given color on its own line.
    public static void WriteLine(string text, ConsoleColor color)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = previousColor;
    }

    // Displays the given text in the given color without a new line.
    public static void Write(string text, ConsoleColor color)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = previousColor;
    }

    // Displays the given question to ask, changes the color to the input
    // color that I typically use (cyan) and then gets the response from the user. 
    public static string Prompt(string questionToAsk)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(questionToAsk + " ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string input = Console.ReadLine();
        Console.ForegroundColor = previousColor;
        return input;
    }
}
