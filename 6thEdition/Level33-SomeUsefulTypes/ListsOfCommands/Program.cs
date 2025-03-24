Robot robot = new Robot();

while (true)
{ 
    string? input = Console.ReadLine();
    
    if (input == "stop") break;

    robot.Commands.Add(input switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand(),
    });
}

Console.WriteLine();

robot.Run();

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = false;
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = true;
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X--; }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X++; }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y--; }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y++; }
}

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand?> Commands { get; } = new List<IRobotCommand?>();
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}