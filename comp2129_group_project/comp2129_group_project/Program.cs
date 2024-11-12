using comp2129_group_project.Entities;
using static comp2129_group_project.Display.Display;

namespace comp2129_group_project
{
    //---------------------------------------------
    //--------- COMP 2129 - Group Project ---------
    //
    // Members:
    //
    // Fellipe C.T.C - 101497831
    // Ayesha Akbar --
    // Claire Lee ----
    // Suthan S. -----
    //
    //---------------------------------------------
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            // Main execution of program
            //

            // Display main menu
            string userInput = MenuMain();

            bool quit = false;
            while (!quit)
            {
                switch (userInput)
                {
                    // Customers
                    case "1":
                        string input1 = MenuCustomers();
                        if (input1 == "0")
                        {
                            userInput = MenuMain();
                        }

                        // TODO: Handle customer menu items
                        break;

                    // Flights
                    case "2":
                        string input2 = MenuFilghts();
                        if (input2 == "0")
                        {
                            userInput = MenuMain();
                        }

                        // TODO: Handle flights menu items
                        break;

                    // Bookings
                    case "3":
                        string input3 = MenuBookings();
                        if (input3 == "0")
                        {
                            userInput = MenuMain();
                        }

                        // TODO: Handle bookings menu items
                        break;

                    // Exit
                    case "0":
                        MenuExit();
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("SWITCH CASE DEFAULT");
                        quit = true;
                        break;
                }
            }
        }
    }
}
