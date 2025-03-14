/// <summary>
/// A simple computer player--an AI. The computer follows a simple set of rules to decide which action to take.
/// </summary>
public class ComputerPlayer : IPlayer
{
    public IAction ChooseAction(Battle battle, Character character)
    {
        // Pretend to think for a bit.
        Thread.Sleep(500);

        // If there's something to attack, attack it with your standard attack.
        List<Character> potentialTargets = battle.GetEnemyPartyFor(character).Characters;
        if (potentialTargets.Count > 0) return new AttackAction(character.StandardAttack, battle.GetEnemyPartyFor(character).Characters[0]);

        // If there's nothing better to do, do nothing.
        return new DoNothingAction();
    }
}
