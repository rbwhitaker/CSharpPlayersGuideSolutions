﻿using System;
using System.Collections.Generic;

/// <summary>
/// A player that retrieves commands from the human through the console window.
/// </summary>
public class ConsolePlayer : IPlayer
{
    public IAction ChooseAction(Battle battle, Character character)
    {
        // This uses a menu-based approach. We create the choices from the menu, including their name, whether they are enabled, and
        // what action to pick if they are enabled and chosen.
        // After that, we display the menu and ask the user to make a selection.
        // If the selected option is enabled, use the action associated with it.

        List<MenuChoice> menuChoices = CreateMenuOptions(battle, character);

        for (int index = 0; index < menuChoices.Count; index++)
            ColoredConsole.WriteLine($"{index + 1} - {menuChoices[index].Description}", menuChoices[index].Enabled ? ConsoleColor.Gray : ConsoleColor.DarkGray);

        string choice = ColoredConsole.Prompt("What do you want to do?");
        int menuIndex = Convert.ToInt32(choice) - 1;

        if (menuChoices[menuIndex].Enabled) return menuChoices[menuIndex].Action;

        return new DoNothingAction(); // <-- This is actually fairly unforgiving. Typing in garbage or attempting to use a disabled option results in doing nothing. It would be better to try again. (Maybe that can be done as a Making It Your Own challenge.
    }

    private List<MenuChoice> CreateMenuOptions(Battle battle, Character character)
    {
        Party currentParty = battle.GetPartyFor(character);
        Party otherParty = battle.GetEnemyPartyFor(character);

        List<MenuChoice> menuChoices = new List<MenuChoice>();

        // Add the standard attack as an option.
        if (otherParty.Characters.Count > 0)
            menuChoices.Add(new MenuChoice($"Standard Attack ({character.StandardAttack.Name})", true, new AttackAction(character.StandardAttack, otherParty.Characters[0])));
        else
            menuChoices.Add(new MenuChoice($"Standard Attack ({character.StandardAttack.Name})", false, null));

        // Add doing nothing as an option.
        menuChoices.Add(new MenuChoice("Do Nothing", true, new DoNothingAction()));

        return menuChoices;
    }
}

public record MenuChoice(string Description, bool Enabled, IAction Action);
