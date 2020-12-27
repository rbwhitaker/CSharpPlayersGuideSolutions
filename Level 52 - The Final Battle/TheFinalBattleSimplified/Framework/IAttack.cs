public interface IAttack
{
    string Name { get; }
    AttackData GenerateData();
}

public record AttackData(int Amount, DamageType Type, double Probability = 1.0);

public enum DamageType { Normal, Decoding, Coding, Fire, Electric, Explosive }

