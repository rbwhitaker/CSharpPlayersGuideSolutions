namespace DuelingTraditions;

// An interface to represent one of many commands in the game. Each new command should
// implement this interface.
public interface ICommand
{
    void Execute(FountainOfObjectsGame game);
}