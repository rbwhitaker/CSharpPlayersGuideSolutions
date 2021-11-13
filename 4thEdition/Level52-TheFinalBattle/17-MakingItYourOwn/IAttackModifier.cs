public interface IAttackModifier
{
    public string Name { get; }
    public AttackData Modify(AttackData input);
}
