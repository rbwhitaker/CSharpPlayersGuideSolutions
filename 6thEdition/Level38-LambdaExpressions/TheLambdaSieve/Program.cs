Console.Write("Which filter do you want to use? (1=Even, 2=Positive, 3=MultipleOfTen) ");
int choice = Convert.ToInt32(Console.ReadLine());

Sieve sieve = choice switch
{
    1 => new Sieve(n => n % 2 == 0),
    2 => new Sieve(n => n > 0),
    3 => new Sieve(n => n % 10 == 0)
};

while (true)
{
    Console.Write("Enter a number: ");
    int number = Convert.ToInt32(Console.ReadLine());

    string goodOrEvil = sieve.IsGood(number) ? "good" : "evil";
    Console.WriteLine($"That number is {goodOrEvil}.");
}

public class Sieve // This is just a wrapper around a `Func<int, bool>` variable. We could have used just that instead in this specific situation.
{
    private Func<int, bool> _decisionFunction;

    public Sieve(Func<int, bool> decisionFunction) => _decisionFunction = decisionFunction;

    public bool IsGood(int number)
    {
        return _decisionFunction(number);
    }
}

// Answer this question: Does this change make the program shorter or longer?
//
//    The program got _slightly_ shorter. I think I removed 3 lines of code and maybe a blank line.
//
// Answer this question: Does this change make the program easier to read or harder?
//
//    I'll admit, when designing this problem, I had assumed it would make the program both shorter
//    and easier to read--a win-win. In actuality, it makes it only a little shorter (the `Sieve`
//    class and the looping mechanism dominate the line count). But notably, in terms of
//    readability, I'm not convinced it makes it better there either. The problem with readability
//    in this case is that a line like `2 => new Sieve(n => n > 0),` doesn't immediately make
//    it clear that I did it right. I have to look up what the `2` means from above.
//
//    Had I done the switch as a string instead of an int, and had the line looked like
//    `"even" => new Sieve(n => n > 0),` then I might say that it does make the code easier to
//    understand.
//
//    While it didn't have the attributes I had initially presumed, it is still a meaningful
//    thing to think about. You always want your code to be understandable upon reading it,
//    and while lambdas often improve readability _and_ shorten the code, that is not a hard
//    and fast rule. You must always be keeping the tradeoffs in mind as you deal with specific
//    situations.