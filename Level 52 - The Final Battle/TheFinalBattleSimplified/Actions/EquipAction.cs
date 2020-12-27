using System;

// An action that allows a character to move an item in the team's shared inventory to their own
// equipment slot so that they can leverage its capabilities.
public class EquipAction : IAction
{
    // The character doing the eqipping.
    private readonly Character _equipper;

    // The equipment being equipped in this caction.
    private readonly IEquipment _equipment;

    // Creates a new EquipAction, specifying the character performing it and the equipment being equipped.
    public EquipAction(Character equipper, IEquipment equipment)
    {
        _equipper = equipper;
        _equipment = equipment;
    }

    // Performs the actual equipping in the context of the battle.
    public void Execute(Battle battle)
    {
        // Uneqip their current item, if they already have something equipped. Move it back to the shared inventory.
        if (_equipper.EquippedItem != null)
        {
            Console.WriteLine($"{_equipper.Name} has unequipped {_equipper.EquippedItem}.");
            battle.GetPartyFor(_equipper).SharedInventory.Equipment.Add(_equipper.EquippedItem);
        }

        // Equip the desired item.
        Console.WriteLine($"{_equipper.Name} has equipped {_equipment.Name}.");
        _equipper.EquippedItem = _equipment;
        battle.GetPartyFor(_equipper).SharedInventory.Equipment.Remove(_equipment);
    }
}
