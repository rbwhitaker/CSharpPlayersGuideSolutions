try
{
    int targetNumber = new Random().Next(10);
    List<int> previousGuesses = new List<int>();

    while (true)
    {
        int number;
        bool previouslyGuessed;
        do
        {
            Console.Write("Pick a number between 0 and 9 (inclusive): ");
            number = Convert.ToInt32(Console.ReadLine());
            previouslyGuessed = previousGuesses.Contains(number);
            if (previouslyGuessed) Console.WriteLine("That number has been guessed before.");
        } while (previouslyGuessed);

        if (number == targetNumber) throw new Exception();

        previousGuesses.Add(number);
    }
}
catch(Exception)
{
    Console.WriteLine("That was the bad number! You lose!");
}

// Answer this question: Did you make a custom exception type or use an existing one, and why did you choose what you did?
//
//    I just used `Exception` because it was easier. For a program this size, it didn't seem justified to build a whole
//    new exception class. (See also my answer to the next question.)
//
// Answer this question: This program could also be written without exceptions, but the requirements demanded an exception
// for learning purposes. If you didn't have that requirement, would you have used an exception, and why or why not?
//
//    In this case, I wouldn't have used an exception. The code that detected the "problem" knows what to do about it.
//    So rather than throwing an exception, I would normally have just done something like use `Console.WriteLine`
//    to display the "You lose!" message, and then `break;` out of the loop and end the program.
