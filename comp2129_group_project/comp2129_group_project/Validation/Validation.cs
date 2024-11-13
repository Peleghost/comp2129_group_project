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

        public static bool CustomerExists(string name, Customer[] customers)
        {
            foreach (Customer customer in customers)
            {
                if (customer.FirstName == name)
                {
                    return true;
                }
            }
                return false;
        }
    }
}
