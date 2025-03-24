PasswordValidator validator = new PasswordValidator();

while (true)
{
    Console.Write("Enter a password: ");
    string? password = Console.ReadLine();

    if (password == null) break; // If the user enters a null password (Ctrl+Z) then let's be done.
                                 // An alternative could be to make `IsValid` handle null or to fall
                                 // back to some default string like the empty string ("") instead.
                                 // This challenge doesn't specifically call out dealing with null,
                                 // and it isn't easy to get a null in there in the first place. If
                                 // you ignored this possibility, that's fine too.

    if (validator.IsValid(password)) Console.WriteLine("That password is valid.");
    else Console.WriteLine("That password is not valid.");
}

public class PasswordValidator
{
    public bool IsValid(string password)
    {
        if (password.Length < 6) return false;
        if (password.Length > 13) return false;
        if (!HasUppercase(password)) return false;
        if (!HasLowercase(password)) return false;
        if (!HasDigits(password)) return false;
        if (Contains(password, 'T')) return false;
        if (Contains(password, '&')) return false;

        return true;
    }

    private bool HasUppercase(string password)
    {
        foreach (char letter in password)
            if (char.IsUpper(letter)) return true;

        return false;
    }

    private bool HasLowercase(string password)
    {
        foreach (char letter in password)
            if (char.IsLower(letter)) return true;

        return false;
    }

    private bool HasDigits(string password)
    {
        foreach (char letter in password)
            if (char.IsDigit(letter)) return true;

        return false;
    }

    private bool Contains(string password, char letter)
    {
        foreach (char character in password)
            if (character == letter) return true;

        return false;
    }
}