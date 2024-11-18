using static comp2129_group_project.Validation.Validation;

namespace comp2129_group_project.Util
{
    public class Util
    {
        // Get user input and validate
        public static string GetInput(int maxInputs)
        {
            try
            {
                string temp = Console.ReadLine()!;
                string result = ValidateUserInput(temp, maxInputs);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
    }
}