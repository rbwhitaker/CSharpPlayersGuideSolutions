Point a = new Point(2, 3);
Point b = new Point(-4, 0);

Console.WriteLine($"({a.X}, {a.Y})");
Console.WriteLine($"({b.X}, {b.Y})");

public class Point
{
    public float X { get; }
    public float Y { get; }

    public Point(float x, float y)
    {
        X = x;
        Y = y;
    }

    public Point() : this(0, 0) { }
}

// Answer this question: Are your X and Y properties immutable? Why did you choose what you did?
//
// Mine are immutable. You can tell because they have no ability to set a new value for either one.
// I chose this simply because I didn't see a compelling reason to make them mutable in the problem
// description, and I typically prefer immutable things to mutable things because they're easier
// to reason about.