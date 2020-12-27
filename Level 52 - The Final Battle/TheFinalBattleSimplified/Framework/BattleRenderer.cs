using System;
using System.Collections.Generic;

// Does the heavy lifting of drawing the status of the game to the player when asked.
public static class BattleRenderer
{
    public static void Render(Battle battle, Character activeCharacter)
    {
        // Display the top banner.
        ColoredConsole.WriteLine($"=================================================== BATTLE #{battle.Number} ===================================================", ConsoleColor.White);

        // Display the heroes and equipped gear.
        foreach (Character character in battle.Heroes.Characters)
        {
            string equippedItemText = character.EquippedItem == null ? "" : $" [{character.EquippedItem.Name}]";
            ColoredConsole.WriteLine($"{character.Name + equippedItemText,-45} ({character.HP,3}/{character.MaxHP,-3})", character == activeCharacter ? ConsoleColor.Yellow : ConsoleColor.Gray);
        }

        // Display the heroes' inventory.
        DisplayInventory(battle.Heroes);

        // Display the middle banner.
        ColoredConsole.WriteLine("------------------------------------------------------ VS -------------------------------------------------------", ConsoleColor.White);

        // Display the monsters and equipped gear.
        foreach (Character character in battle.Monsters.Characters)
        {
            string equippedItemText = character.EquippedItem == null ? "" : $" [{character.EquippedItem.Name}]";
            ColoredConsole.WriteLine($"                                                          {character.Name + equippedItemText,45} ({character.HP,3}/{character.MaxHP,-3})", character == activeCharacter ? ConsoleColor.Yellow : ConsoleColor.Gray);
        }

        // Display the bottom banner.
        ColoredConsole.WriteLine("=================================================================================================================", ConsoleColor.White);
    }

    // Displays the inventory of a given party.
    private static void DisplayInventory(Party party)
    {
        // Items
        ColoredConsole.Write($"ITEMS:", ConsoleColor.Cyan);

        // Use a dictionary that maps strings to their counts. Get the name of each item
        // and either add it to the dictionary with an initial count of 1 or if it is already
        // in the dictionary, add one to it. This allows us to display things like "HEALTH POTION (3)"
        // instead of "HEALTH POTION, HEALTH POTION, HEALTH POTION".
        Dictionary<string, int> itemCounts = new Dictionary<string, int>();
        foreach (IItem item in party.SharedInventory.Items)
            if (itemCounts.ContainsKey(item.Name))
                itemCounts[item.Name]++;
            else
                itemCounts[item.Name] = 1;

        // On the first one, we don't want to include a ", ". On every one after that, we do want that.
        bool first = true;
        foreach (string key in itemCounts.Keys)
        {
            ColoredConsole.Write(first ? "" : ", ", ConsoleColor.Cyan);
            ColoredConsole.Write(key + (itemCounts[key] > 1 ? $" ({itemCounts[key]})" : ""), ConsoleColor.Cyan);
            first = false;
        }

        Console.WriteLine();

        // Equipment. This works in the same was as the items above.
        ColoredConsole.Write($"EQUIPMENT:", ConsoleColor.Yellow);
        Dictionary<string, int> equipmentCounts = new Dictionary<string, int>();
        foreach (IEquipment equipment in party.SharedInventory.Equipment)
            if (equipmentCounts.ContainsKey(equipment.Name))
                equipmentCounts[equipment.Name]++;
            else
                equipmentCounts[equipment.Name] = 1;

        first = true;
        foreach (string key in equipmentCounts.Keys)
        {
            ColoredConsole.Write(first ? "" : ", ", ConsoleColor.Yellow);
            ColoredConsole.Write(key + (equipmentCounts[key] > 1 ? $" ({equipmentCounts[key]})" : ""), ConsoleColor.Yellow);
            first = false;
        }

        Console.WriteLine();
    }
}
