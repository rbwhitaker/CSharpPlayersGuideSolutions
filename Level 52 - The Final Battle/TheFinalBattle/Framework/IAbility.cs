// Represents a single ability in the system. As it is currently defined,
// this ability is passive--you don't use an ability *on* something, you
// just use an ability.
public interface IAbility
{
    // The name of the ability.
    string Name { get; }

    // Allows the ability to run its course. The user is the user who's ability
    // it is and who is running the ability. The battle gives you the full
    // context and access to the rest of what is going on.
    void Use(Battle battle, Character user);
}

