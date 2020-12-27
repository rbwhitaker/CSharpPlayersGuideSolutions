using System;

// An action type that allows a user to use an item for themseles.
public class UseItemAction : IAction
{
    // The character using the item.
    private readonly Character _user;

    // The item being used.
    private readonly IItem _item;

    // Creates a new UseItemAction, with the character performing it and the item being used
    // for future reference when running.
    public UseItemAction(Character user, IItem item)
    {
        _user = user;
        _item = item;
    }

    // Runs the action in the context of the battle.
    public void Execute(Battle battle)
    {
        Console.WriteLine($"{_user.Name} used {_item.Name}.");

        // Use the item.
        _item.Use(battle, _user);

        // Items are considered consumed after use. Remove it from inventory.
        battle.GetPartyFor(_user).SharedInventory.Items.Remove(_item);
    }
}
