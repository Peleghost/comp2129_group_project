using comp2129_group_project.Entities;
using System.Text.RegularExpressions;

namespace comp2129_group_project.Validation
{
    public class Validation
    {
        // Validate user input
        // Where <maxInputs> is the number of inputs available for a given menu
        public static string ValidateUserInput(string userInput, int maxInputs)
        {
            try
            {
                string pattern = $"[0-{maxInputs}]";
                var regex = new Regex(pattern);

                while (!regex.IsMatch(userInput!) || Convert.ToInt32(userInput) > maxInputs)
                {
                    Console.WriteLine("Please enter a valid selection! ");
                    Console.Write("> ");
                    userInput = Console.ReadLine()!;
                }

                return userInput;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public static bool ValidateName(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Name cannot be empty or contain only spaces.");
                return false;
            }

          
            if (input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '\'' || c == '-'))
            {
                
                if (input.Length < 2 || input.Length > 50)
                {
                    Console.WriteLine("Name must be between 2 and 50 characters.");
                    return false;
                }

                return true;
            }
            else
            {
                Console.WriteLine("Name must contain only letters, spaces, hyphens, or apostrophes.");
                return false;
            }
        }


    }
}
