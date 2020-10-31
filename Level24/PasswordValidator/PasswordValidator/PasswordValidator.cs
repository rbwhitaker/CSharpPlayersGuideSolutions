namespace PasswordValidator
{
    public class PasswordValidator
    {
        public bool IsValid(string password)
        {
            if (password.Length < 6) return false;
            if (password.Length > 13) return false;
            if (HasUppercase(password)) return false;
            if (HasLowercase(password)) return false;
            if (HasDigits(password)) return false;
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
}
