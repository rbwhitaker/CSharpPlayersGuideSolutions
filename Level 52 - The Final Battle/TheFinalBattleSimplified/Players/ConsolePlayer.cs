using System;
using System.Collections.Generic;

public record MenuOption(int Number, string Label, bool Enabled, Func<IAction> Response);

public class ConsolePlayer : IPlayer
{
    public IAction PickAction(Battle battle, Character character)
    {
        Console.WriteLine($"It is {character.Name}'s turn!");

        List<MenuOption> menuOptions = new List<MenuOption>();
        if (character.EquippedItem == null)
            menuOptions.Add(new MenuOption(1, "Weapon Attack - (nothing equipped)", false, null));
        else
            menuOptions.Add(new MenuOption(1, $"Weapon Attack - {character.EquippedItem.Attack.Name}", true, () => new AttackAction(character, character.EquippedItem.Attack, battle.GetOpposingParty(character).Characters[0])));

        menuOptions.Add(new MenuOption(2, $"Basic Attack - {character.Attack.Name}", true, () => new AttackAction(character, character.Attack, battle.GetOpposingParty(character).Characters[0])));
        menuOptions.Add(new MenuOption(3, "Use Item", battle.GetPartyFor(character).SharedInventory.Items.Count > 0, () => PickItemToUse(battle, character)));
        menuOptions.Add(new MenuOption(4, "Equip Item", battle.GetPartyFor(character).SharedInventory.Equipment.Count > 0, () => PickEquipmentToUse(battle, character)));
        menuOptions.Add(new MenuOption(5, $"Ability - {character.Ability.Name}", battle.GetPartyFor(character).SharedInventory.Equipment.Count > 0, () => PickEquipmentToUse(battle, character)));
        menuOptions.Add(new MenuOption(6, "Do Nothing", true, () => new DoNothingAction(character)));

        while (true)
        {
            foreach (MenuOption menuOption in menuOptions)
                ColoredConsole.WriteLine($"{menuOption.Number,2} - {menuOption.Label}", menuOption.Enabled ? ConsoleColor.Gray : ConsoleColor.DarkGray);

            string input = ColoredConsole.Prompt("What is your choice?");


            IAction action;
            if (input == "1") action = new AttackAction(character, character.EquippedItem.Attack, battle.GetOpposingParty(character).Characters[0]);
            else if (input == "2") action = new AttackAction(character, character.Attack, battle.GetOpposingParty(character).Characters[0]);
            else if (input == "3") action = PickItemToUse(battle, character);
            else if (input == "4") action = PickEquipmentToUse(battle, character);
            else if (input == "5") action = new UseAbilityAction(character, character.Ability);
            else if (input == "6") action = new DoNothingAction(character);
            else { ColoredConsole.WriteLine($"I did not understand '{input}'. Pick from the options above.", ConsoleColor.Red); continue; }

            if (action != null) return action;
        }
    }

    private IAction PickItemToUse(Battle battle, Character character)
    {
        List<IItem> inventory = battle.GetPartyFor(character).SharedInventory.Items;

        while (true)
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine($"{character.Name} has no items to use.");
            }
            else
            {
                Console.WriteLine("Choose an item to use below:");
                for (int index = 0; index < inventory.Count; index++)
                {
                    IItem item = inventory[index];
                    Console.WriteLine($"{index + 1,2} - {item.Name}");
                }
            }
            Console.WriteLine(" X - Cancel");

            string input = ColoredConsole.Prompt("What is your choice?");

            if (input.ToUpper() == "X") return null;

            if (int.TryParse(input, out int choice))
            {
                int chosenIndex = choice - 1;
                IAction result = new UseItemAction(character, inventory[chosenIndex]);
                if (result == null) continue;
                return result;
            }

            ColoredConsole.WriteLine($"I did not understand '{input}'. Pick from the options above.", ConsoleColor.Red);
        }
    }

    private IAction PickEquipmentToUse(Battle battle, Character character)
    {
        List<IEquipment> inventory = battle.GetPartyFor(character).SharedInventory.Equipment;

        while (true)
        {
            if(inventory.Count == 0)
            {
                Console.WriteLine($"{character.Name} has no items available.");
            }
            else
            {
                Console.WriteLine("Choose an item below:");

                for (int index = 0; index < inventory.Count; index++)
                {
                    IEquipment item = inventory[index];
                    Console.WriteLine($"{index + 1,2} - {item.Name}");
                }
            }
            Console.WriteLine(" X - Cancel");

            string input = ColoredConsole.Prompt("What is your choice?");

            if (input.ToUpper() == "X") return null;

            if (int.TryParse(input, out int choice))
            {
                int chosenIndex = choice - 1;
                IAction result = new EquipAction(character, inventory[chosenIndex]);
                if (result == null) continue;
                return result;
            }

            ColoredConsole.WriteLine($"I did not understand '{input}'. Pick from the options above.", ConsoleColor.Red);
        }
    }
}
