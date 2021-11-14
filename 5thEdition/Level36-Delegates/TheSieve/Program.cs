Console.Write("Which filter do you want to use? (1=Even, 2=Positive, 3=MultipleOfTen) ");
int choice = Convert.ToInt32(Console.ReadLine());

Sieve sieve = choice switch
{
    1 => new Sieve(IsEven),
    2 => new Sieve(IsPositive),
    3 => new Sieve(IsMultipleOfTen)
};

while (true)
{
    Console.Write("Enter a number: ");
    int number = Convert.ToInt32(Console.ReadLine());

    string goodOrEvil = sieve.IsGood(number) ? "good" : "evil";
    Console.WriteLine($"That number is {goodOrEvil}.");
}

bool IsEven(int number) => number % 2 == 0;
bool IsPositive(int number) => number > 0;
bool IsMultipleOfTen(int number) => number % 10 == 0;

public class Sieve
{
    private Func<int, bool> _decisionFunction;

    public Sieve(Func<int, bool> decisionFunction) => _decisionFunction = decisionFunction;

    public bool IsGood(int number)
    {
        return _decisionFunction(number);
    }
}