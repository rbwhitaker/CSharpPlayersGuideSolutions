Console.WriteLine("How many estates do you have?");
int estateCount = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How many duchies do you have?");
int duchyCount = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How many provinces do you have?");
int provinceCount = Convert.ToInt32(Console.ReadLine());

int total = estateCount * 1 + duchyCount * 3 + provinceCount * 6;

Console.WriteLine("Your point total: " + total);