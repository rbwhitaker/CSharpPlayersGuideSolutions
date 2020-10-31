using System;

namespace TheColor
{
    class Program
    {
        static void Main(string[] args)
        {
            Color c1 = new Color(2, 4, 8);
            Color c2 = Color.Orange;

            Console.WriteLine($"R={c1.R} G={c1.G} B={c1.B}");
            Console.WriteLine($"R={c2.R} G={c2.G} B={c2.B}");
        }
    }
}
