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

        public static string ValidatePhoneNum(string phoneNum)
        {
            // Validate customer phone number
            string pattern = @"\(\d{3}\)\d{3} \d{4}";

            while (!Regex.IsMatch(phoneNum, pattern))
            {
                Console.WriteLine("Make sure phone number is following this format:");
                Console.WriteLine("(123)456 7890");
                phoneNum = Console.ReadLine()!;
            }

            return phoneNum;
        }
    }
}
