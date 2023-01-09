Console.Write("x: ");
int x = Convert.ToInt32(Console.ReadLine());
Console.Write("y: ");
int y = Convert.ToInt32(Console.ReadLine());

if (x < 0  && y > 0)  Console.WriteLine("The enemy is to the north west!");
if (x == 0 && y > 0)  Console.WriteLine("The enemy is to the north!");
if (x > 0  && y > 0)  Console.WriteLine("The enemy is to the north east!");
if (x < 0  && y == 0) Console.WriteLine("The enemy is to the west!");
if (x == 0 && y == 0) Console.WriteLine("The enemy is here!");
if (x > 0  && y == 0) Console.WriteLine("The enemy is to the east!");
if (x < 0  && y < 0)  Console.WriteLine("The enemy is to the south west!");
if (x == 0 && y < 0)  Console.WriteLine("The enemy is to the south!");
if (x > 0  && y < 0)  Console.WriteLine("The enemy is to the south east!");