/// <summary>
/// A simple computer player--an AI. The computer follows a simple set of rules to decide which action to take.
/// </summary>
public class ComputerPlayer : IPlayer
{
    private static Random _random = new Random();

    public IAction ChooseAction(Battle battle, Character character)
    {
        // Pretend to think for a bit.
        Thread.Sleep(50);

        // If there is a potion, and if the character's health is low (less than 50%), then 25% of the time, use a potion.
        bool hasPotion = battle.GetPartyFor(character).Items.Count > 0; // Not quite right. This assumes all items are potions, which is true for now but could change later.
        bool isHPUnderThreshold = character.HP / (float)character.MaxHP < 0.5;
        if (hasPotion && isHPUnderThreshold && _random.NextDouble() < 0.25)
            return new UseItemAction(battle.GetPartyFor(character).Items[0]);

        if (character.EquippedGear == null && battle.GetPartyFor(character).Gear.Count > 0 && _random.NextDouble() < 0.5)
            return new EquipGearAction(battle.GetPartyFor(character).Gear[0]);

        // If there's something to attack, attack it with your standard attack.
        List<Character> potentialTargets = battle.GetEnemyPartyFor(character).Characters;
        if (potentialTargets.Count > 0)
        {
            Character target = potentialTargets[_random.Next(potentialTargets.Count)];
            // Prefer attacks from equipped gear to the standard attack.
            if (character.EquippedGear != null) return new AttackAction(character.EquippedGear.Attack, target);
            else return new AttackAction(character.StandardAttack, target);
        }

        // If there's nothing better to do, do nothing.
        return new DoNothingAction();
    }
}
