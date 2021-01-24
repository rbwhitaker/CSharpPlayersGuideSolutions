using System;

for (int number = 1; number <= 100; number++)
{
    if (number % 5 == 0 && number % 3 == 0) Console.WriteLine($"{number}: Electric and Fire");
    else if (number % 5 == 0) Console.WriteLine($"{number}: Electric");
    else if (number % 3 == 0) Console.WriteLine($"{number}: Fire");
    else Console.WriteLine($"{number}: Normal");
}