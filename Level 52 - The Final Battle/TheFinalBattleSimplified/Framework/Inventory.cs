using System;
using System.Collections.Generic;

public class Inventory
{
    public List<IItem> Items { get; } = new List<IItem>();
    public List<IEquipment> Equipment { get; } = new List<IEquipment>();

    public void TransferInventory(Inventory target)
    {
        foreach (IItem item in Items)
        {
            ColoredConsole.WriteLine($"Acquired {item.Name}.", ConsoleColor.DarkMagenta);
            target.Items.Add(item);
        }
        Items.Clear();

        foreach (IEquipment equipment in Equipment)
        {
            ColoredConsole.WriteLine($"Acquired {equipment.Name}.", ConsoleColor.DarkMagenta);
            target.Equipment.Add(equipment);
        }
        Items.Clear();
    }
}

public interface IItem
{
    void Use(Battle battle, Character user);
    string Name { get; }
}

public interface IEquipment
{
    string Name { get; }
    IAttack Attack { get; }
}



