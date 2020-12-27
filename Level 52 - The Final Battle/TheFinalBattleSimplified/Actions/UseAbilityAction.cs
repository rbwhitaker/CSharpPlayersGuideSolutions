// An action that allows an ability to run.
public class UseAbilityAction : IAction
{
    // The character activating the ability.
    private Character _user;

    // The ability that should run.
    private IAbility _ability;

    // Creates a new UseAbilityAction with the user, the ability, and the target
    // all spelled out for use when it executes.
    public UseAbilityAction(Character user, IAbility ability)
    {
        _ability = ability;
        _user = user;
    }

    // Actually activates the ability.
    public void Execute(Battle battle) => _ability.Use(battle, _user);
}
