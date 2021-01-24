using System;

Color random = new Color(2, 200, 20);
Color fixedColor = Color.Orange;

Console.WriteLine($"R={random.R} G={random.G} B={random.B}");
Console.WriteLine($"R={fixedColor.R} G={fixedColor.G} B={fixedColor.B}");

public class Color
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public static Color White  = new Color(255,  255,  255);
    public static Color Black  = new Color(  0,    0,    0);
    public static Color Red    = new Color(255,    0,    0);
    public static Color Orange = new Color(255,  165,    0);
    public static Color Yellow = new Color(255,  255,    0);
    public static Color Green  = new Color(  0,  128,    0);
    public static Color Blue   = new Color(  0,    0,  255);
    public static Color Purple = new Color(128,    0,  128);
}