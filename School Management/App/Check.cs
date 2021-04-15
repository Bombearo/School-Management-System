using System;

namespace School_Management.App
{
    public partial class Views
    {
        private static bool CheckCancel(string[] possibleAnswers)
        {
            Console.WriteLine("Would you like to cancel?");
            var input = Console.ReadLine();
            return (!Array.Exists(possibleAnswers, answer => input != null && answer == input.ToLower()));
        }

        private static bool CheckBonus()
        {
            while (true)
            {
                Console.WriteLine("Would you like to grant a bonus? (Y/N)");
                var input = Console.ReadLine();
                var lower = input?.ToLower();
                switch (lower)
                {
                    case "y":
                    case "ye":
                    case "yes":
                        return true;
                    case "n":
                    case "no":
                        return false;
                }
                Console.WriteLine("Please enter Y/N to answer. ALl other inputs won't be accepted");
            }
        }
    }
}