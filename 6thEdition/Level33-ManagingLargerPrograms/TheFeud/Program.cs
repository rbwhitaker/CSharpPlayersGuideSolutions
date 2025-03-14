using IField;
using McDroid;
using McPig = McDroid.Pig; // Part of the alias approach.

// These don't need to be disambiguated.
Sheep sheep = new Sheep();
Cow cow = new Cow();

IField.Pig pig1 = new IField.Pig(); // The fully-qualified name approach.
McPig pig2 = new McPig();       // The alias approach.



namespace IField
{
    public class Sheep { }
    public class Pig { }
}

namespace McDroid
{
    public class Cow { }
    public class Pig { }
}