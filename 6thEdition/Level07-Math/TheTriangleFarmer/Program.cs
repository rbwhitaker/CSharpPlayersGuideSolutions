Console.WriteLine("What is the triangle's width?");
string widthText = Console.ReadLine();
float width = Convert.ToSingle(widthText);

Console.WriteLine("What is the triangle's height?");
string heightText = Console.ReadLine();
float height = Convert.ToSingle(heightText);

float area = (width * height) / 2;
Console.WriteLine("The area is " + area);