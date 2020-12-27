using System.Collections.Generic;

public interface IAttack
{
    string Name { get; }
    AttackData GenerateData();
    List<IAttackSideEffect> SideEffects { get; }
}

public interface IAttackSideEffect
{
    void Perform(Battle battle, Character attacker, IAttack attack, Character target, AttackData initialData, AttackData finalData);
}

public record AttackData(int Amount, DamageType Type, double Probability = 1.0);

public enum DamageType { Normal, Decoding, Coding, Fire, Electric, Explosive }

