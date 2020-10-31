using System;

namespace Point
{
    public class Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point() : this(0, 0) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(2, 3);
            Point p2 = new Point(-4, 0);

            Console.WriteLine($"({p1.X}, {p1.Y})");
            Console.WriteLine($"({p2.X}, {p2.Y})");
        }
    }
}
