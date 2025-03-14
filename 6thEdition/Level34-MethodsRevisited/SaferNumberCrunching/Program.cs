int number;
do
{
    Console.Write("Enter an integer: ");
} while (!int.TryParse(Console.ReadLine(), out number));
Console.WriteLine(number);

double number2;
do
{
    Console.Write("Enter a number: ");
} while (!double.TryParse(Console.ReadLine(), out number2));
Console.WriteLine(number2);

bool truthValue;
do
{
    Console.Write("Enter true or false: ");
} while (!bool.TryParse(Console.ReadLine(), out truthValue));
Console.WriteLine(truthValue);
