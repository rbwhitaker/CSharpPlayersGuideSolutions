using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordValidator validator = new PasswordValidator();

            while (true)
            {
                Console.Write("Enter a password: ");
                string password = Console.ReadLine();

                if (validator.IsValid(password))
                    Console.WriteLine("That password meets all criteria.");
                else
                    Console.WriteLine("That password does not meet all criteria.");
            }
        }
    }
}
