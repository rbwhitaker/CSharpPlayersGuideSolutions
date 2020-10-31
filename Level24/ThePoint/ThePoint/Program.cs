using System;

namespace Point
{
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
