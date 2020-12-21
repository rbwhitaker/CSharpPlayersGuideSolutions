using Flame;
using Frost;
using DoublePig = Flame.Pig; // Part of the alias approach.

// These don't need to be disambiguated.
Sheep sheep = new Sheep();
Cow cow = new Cow();

Frost.Pig pig1 = new Frost.Pig(); // The fully-qualified name approach.
DoublePig pig2 = new DoublePig();       // The alias approach.


namespace Flame
{
    public class Sheep { }
    public class Pig { }
}

namespace Frost
{
    public class Cow { }
    public class Pig { }
}