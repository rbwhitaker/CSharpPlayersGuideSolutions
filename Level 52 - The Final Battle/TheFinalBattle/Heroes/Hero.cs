public abstract class Hero : Character
{
    public Hero(int hp) : base(hp) { }
}

public abstract class Companion : Hero
{
    public Companion(int hp) : base(hp) { }
}

