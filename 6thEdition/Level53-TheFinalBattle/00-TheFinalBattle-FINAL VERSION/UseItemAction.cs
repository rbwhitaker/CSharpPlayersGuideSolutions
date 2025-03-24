/// <summary>
/// An action type that uses an item.
/// </summary>
public class UseItemAction : IAction
{
    // The item to use.
    private readonly IItem _item;

    /// <summary>
    /// Creates a new UseItemAction with the item to use.
    /// </summary>
    public UseItemAction(IItem item) => _item = item;

    public void Run(Battle battle, Character actor)
    {
        // Tell the user that the character is using the item.
        Console.WriteLine($"{actor.Name} used {_item.Name}.");

        // Use the item.
        _item.Use(battle, actor);

        // Items are consumed after use.
        battle.GetPartyFor(actor).Items.Remove(_item);
    }
}
