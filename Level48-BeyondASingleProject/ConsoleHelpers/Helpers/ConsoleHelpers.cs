using System;

namespace Helpers
{
    public static class ConsoleHelpers
    {
        public static int AskForNumber(string question, int minimum, int maximum)
        {
            while (true)
            {
                Console.Write(question + " ");
                int number = Convert.ToInt32(Console.ReadLine());
                if (number >= minimum && number <= maximum)
                    return number;

                Console.WriteLine($"That number is not in the right range [{minimum} to {maximum}]. Try again.");
            }
        }
    }
}
