/// <summary>
/// A simple computer player--an AI. The computer follows a simple set of rules to decide which action to take.
/// </summary>
public class ComputerPlayer : IPlayer
{
    private static Random _random = new Random();

    public IAction ChooseAction(Battle battle, Character character)
    {
        // Pretend to think for a bit.
        Thread.Sleep(500);

        // If there is a potion, and if the character's health is low (less than 50%), then 25% of the time, use a potion.
        bool hasPotion = battle.GetPartyFor(character).Items.Count > 0; // Not quite right. This assumes all items are potions, which is true for now but could change later.
        bool isHPUnderThreshold = character.HP / (float)character.MaxHP < 0.5;
        if (hasPotion && isHPUnderThreshold && _random.NextDouble() < 0.25)
            return new UseItemAction(battle.GetPartyFor(character).Items[0]);

        // If there's something to attack, attack it with your standard attack.
        List<Character> potentialTargets = battle.GetEnemyPartyFor(character).Characters;
        if (potentialTargets.Count > 0) return new AttackAction(character.StandardAttack, battle.GetEnemyPartyFor(character).Characters[0]);

        // If there's nothing better to do, do nothing.
        return new DoNothingAction();
    }
}
