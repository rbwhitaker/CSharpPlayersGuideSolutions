using System;

// A simple action where the character does nothing and wastes/passes on their turn.
public class DoNothingAction : IAction
{
    private readonly Character _character;
    public DoNothingAction(Character character) => _character = character;
    public void Execute(Battle battle) => Console.WriteLine($"{_character.Name} did NOTHING.");
}
