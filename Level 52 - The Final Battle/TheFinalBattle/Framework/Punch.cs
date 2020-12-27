﻿using System.Collections.Generic;

public class Punch : IAttack
{
    public string Name => "PUNCH";
    public AttackData GenerateData() => new AttackData(1, DamageType.Normal);
    public List<IAttackSideEffect> SideEffects { get; } = new List<IAttackSideEffect>();
}
