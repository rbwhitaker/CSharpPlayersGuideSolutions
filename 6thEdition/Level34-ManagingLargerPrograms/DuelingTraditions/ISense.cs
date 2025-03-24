namespace DuelingTraditions;

// Represents something that the player can sense as they wander the caverns.
public interface ISense
{
    // Returns whether the player should be able to sense the thing in question.
    bool CanSense(FountainOfObjectsGame game);

    // Displays the sensed information. (Assumes `CanSense` was called first and returned `true`.)
    void DisplaySense(FountainOfObjectsGame game);
}