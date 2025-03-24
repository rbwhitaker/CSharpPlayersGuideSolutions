public static class BattleRenderer
{
    public static void Render(Battle battle, Character activeCharacter)
    {
        // Display the top banner.
        ColoredConsole.WriteLine($"===================================================== BATTLE ====================================================", ConsoleColor.White);

        // Display the heroes and equipped gear.
        foreach (Character character in battle.Heroes.Characters)
        {
            string gearString = character.EquippedGear == null ? "" : $" [{character.EquippedGear.Name}]";
            ConsoleColor color = character == activeCharacter ? ConsoleColor.Yellow : ConsoleColor.Gray;
            ColoredConsole.WriteLine($"{character.Name + gearString,-45} ({character.HP,3}/{character.MaxHP,-3})", color);
        }

        // Display the middle banner.
        ColoredConsole.WriteLine("------------------------------------------------------ VS -------------------------------------------------------", ConsoleColor.White);

        // Display the monsters and equipped gear.
        foreach (Character character in battle.Monsters.Characters)
        {
            string gearString = character.EquippedGear == null ? "" : $" [{character.EquippedGear.Name}]";
            ConsoleColor color = character == activeCharacter ? ConsoleColor.Yellow : ConsoleColor.Gray;
            ColoredConsole.WriteLine($"                                                          {character.Name + gearString,45} ({character.HP,3}/{character.MaxHP,-3})", color);
        }

        // Display the bottom banner.
        ColoredConsole.WriteLine("=================================================================================================================", ConsoleColor.White);
    }
}

