using System;

namespace TheLockedDoor
{
    class Program
    {
        static void Main(string[] args)
        {
            int passcode = PromptForNumber("What is the initial numeric passcode?");
         
            Door door = new Door(passcode);

            while(true)
            {
                Console.WriteLine($"The door is {door.State}.");
                Console.Write("What now? (Options are 'open', 'close', 'lock', 'unlock', and 'change'.)");
                string command = Console.ReadLine();
                
                switch(command)
                {
                    case "open":
                        door.Open();
                        break;
                    case "close":
                        door.Close();
                        break;
                    case "lock":
                        door.Lock();
                        break;
                    case "unlock":
                        UnlockDoor(door);
                        break;
                    case "change":
                        ChangeCode(door);
                        break;
                }
            }
        }

        private static void ChangeCode(Door door)
        {
            int currentCode = PromptForNumber("What is the current passcode?");
            int newCode = PromptForNumber("What do you want to change it to?");
            
            bool success = door.TryChangeCode(currentCode, newCode);

            if (success) Console.WriteLine("Code successfully changed.");
            else Console.WriteLine("That code was not right. Passcode not changed.");
        }

        private static void UnlockDoor(Door door)
        {
            int guess = PromptForNumber("What is the passcode?");
            door.TryUnlock(guess);
        }

        private static int PromptForNumber(string message)
        {
            Console.Write(message + " ");
            string input = Console.ReadLine();
            int number = Convert.ToInt32(input);
            return number;
        }
    }
}
