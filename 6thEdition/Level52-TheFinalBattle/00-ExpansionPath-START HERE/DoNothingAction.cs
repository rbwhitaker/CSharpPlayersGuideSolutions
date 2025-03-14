/// <summary>
/// An action type that does nothing (besides say that the character did nothing).
/// </summary>
public class DoNothingAction : IAction
{
    public void Run(Battle battle, Character actor) => Console.WriteLine($"{actor.Name} did NOTHING.");
}
