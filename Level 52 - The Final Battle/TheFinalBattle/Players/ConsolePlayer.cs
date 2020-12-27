using System;
using System.Collections.Generic;

public class ConsolePlayer : IPlayer
{
    public IAction PickAction(Battle battle, Character character)
    {
        Console.WriteLine($"It is {character.Name}'s turn!");
        while (true)
        {
            Console.WriteLine(" 1 - Attack");
            Console.WriteLine(" 2 - Use Item");
            Console.WriteLine(" 3 - Equip Item");
            Console.WriteLine(" 4 - Use Ability");
            Console.WriteLine(" 5 - Do Nothing");

            string input = ColoredConsole.Prompt("What is your choice?");
            IAction action;
            if (input == "1") action = PickAttack(battle, character);
            else if (input == "2") action = PickItemToUse(battle, character);
            else if (input == "3") action = PickItemToEquip(battle, character);
            else if (input == "4") action = PickAbilityToUse(battle, character);
            else if (input == "5") action = new DoNothingAction(character);
            else { ColoredConsole.WriteLine($"I did not understand '{input}'. Pick from the options above.", ConsoleColor.Red); continue; }

            if (action != null) return action;
        }
    }

    private IAction PickAbilityToUse(Battle battle, Character character)
    {
        List<IAbility> abilities = character.AllCapabilities.Abilities;

        while (true)
        {
            if(abilities.Count == 0)
            {
                Console.WriteLine($"{character.Name} has no abilities available.");
            }
            else
            {
                Console.WriteLine("Choose an ability below:");
                for (int index = 0; index < abilities.Count; index++)
                {
                    IAbility ability = abilities[index];
                    Console.WriteLine($"{index + 1,2} - {ability.Name}");
                }
            }

            Console.WriteLine(" X - Cancel");

            string input = ColoredConsole.Prompt("What is your choice?");

            if (input.ToUpper() == "X") return null;

            if (int.TryParse(input, out int choice))
            {
                int chosenIndex = choice - 1;
                IAction result = new UseAbilityAction(character, abilities[chosenIndex]);
                if (result == null) continue;
                return result;
            }

            ColoredConsole.WriteLine($"I did not understand '{input}'. Pick from the options above.", ConsoleColor.Red);
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

    private IAction PickItemToEquip(Battle battle, Character character)
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

    private IAction PickAttack(Battle battle, Character character)
    {
        while (true)
        {
            if (character.AllCapabilities.Attacks.Count == 0)
            {
                Console.WriteLine($"{character.Name} has no attacks available.");
            }
            else
            {
                Console.WriteLine("Choose from the attacks below.");
                for (int index = 0; index < character.AllCapabilities.Attacks.Count; index++)
                {
                    IAttack attack = character.AllCapabilities.Attacks[index];
                    Console.WriteLine($"{index + 1,2} - {attack.Name}");
                }
            }

            Console.WriteLine(" X - Cancel");

            string input = ColoredConsole.Prompt("What is your choice?");
            if (input.ToUpper() == "X") return null;
            if (int.TryParse(input, out int choice) && choice - 1 < character.AllCapabilities.Attacks.Count)
                return new AttackAction(character, character.AllCapabilities.Attacks[choice - 1], battle.GetOpposingParty(character).Characters[0]);

            Console.WriteLine($"I did not understand '{input}'. Pick from the options above.");
        }
    }
}
