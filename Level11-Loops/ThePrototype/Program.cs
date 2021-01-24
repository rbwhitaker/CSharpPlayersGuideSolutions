using System;

Console.Write("User 1, enter a number between 0 and 100: ");
int number = Convert.ToInt32(Console.ReadLine());

Console.Clear();

Console.WriteLine("User 2, guess the number.");

while(true)
{
    Console.Write("What is your next guess? ");
    int guess = Convert.ToInt32(Console.ReadLine());

    if (guess > number) Console.WriteLine($"{guess} is too high.");
    else if (guess < number) Console.WriteLine($"{guess} is too low.");
    else break;
}

Console.WriteLine("You guessed the number!");