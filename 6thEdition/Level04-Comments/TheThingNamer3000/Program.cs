Console.WriteLine("What kind of thing are we talking about?");

// Thing type.
string a = Console.ReadLine();
Console.WriteLine("How would you describe it? Big? Azure? Tattered?");

// Description.
string b = Console.ReadLine();

// "of Doom" text.
string c = "Doom"; // Modified to fix the "of of" bug.

/* The number. */
string d = "3000";

Console.WriteLine("The " + b + " " + a + " of " + c + " " + d + "!");

// Answer this question: Aside from comments, what else could do to make this code more understandable?
//   Better variable names is one possibility. I'd rename `a` to `type`, `b` to `description`, `c` to `doom`, and `d` to
//   `version` or something like that.