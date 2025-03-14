/// <summary>
/// Represents an attack that a character might have. Each attack has a name and the ability
/// to produce attack data by request, for when somebody uses the attack.
/// </summary>
public interface IAttack
{
    /// <summary>
    /// The name of the attack.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Creates new attack data. Called when a character uses an attack.
    /// </summary>
    AttackData Create();
}

/// <summary>
/// The collection of information that defines a specific usage or occurence of an attack.
/// </summary>
public record AttackData(int Damage, double ProbabilityOfHitting = 1.0);