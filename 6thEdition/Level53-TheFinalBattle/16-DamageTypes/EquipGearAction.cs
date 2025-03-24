public class EquipGearAction : IAction
{
    private readonly IGear _gear;

    public EquipGearAction(IGear gear) => _gear = gear;

    public void Run(Battle battle, Character actor)
    {
        Party party = battle.GetPartyFor(actor);

        // If we already have equipped gear, unequip it first.
        if (actor.EquippedGear != null)
        {
            Console.WriteLine($"{actor.Name} has unequipped {_gear.Name}.");
            party.Gear.Add(actor.EquippedGear);
            actor.EquippedGear = null;
        }
        
        // Tell the user that the character is equipping the gear.
        Console.WriteLine($"{actor.Name} equipped {_gear.Name}.");
        actor.EquippedGear = _gear;
        party.Gear.Remove(_gear);
    }
}
