public interface IAttackModifier
{
    AttackData Modify(AttackData input, Battle battle, Character attacker, Character target);
}
