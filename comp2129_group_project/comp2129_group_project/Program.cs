using comp2129_group_project.Managers;
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
    // Ayesha Akbar 100949840
    // Claire Lee ----
    // Suthan S. -----
    //                         
    //---------------------------------------------
    internal class Program
    {
        private static CustomerManager customerManager = new CustomerManager(10); // Maximum 10 customers

        static void Main(string[] args)
        {
            //
            // Main execution of program
            //

            FileManager fileManager = new FileManager();
            fileManager.CreateFiles();

            // Display main menu
            string userInput = MenuMain();

            bool quit = false;
            while (!quit)
            {
                switch (userInput)
                {
                    // Customers
                    case "1":
                        HandleCustomerMenu();
                        userInput = MenuMain();
                        break;

                    // Flights
                    case "2":
                        string input2 = MenuFlights();
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
                        Console.WriteLine("Sorry this is an invalid choice. Please try again.");
                        quit = true;
                        break;
                }
            }
        }

        static void HandleCustomerMenu()
        {
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                string input = MenuCustomers();

                switch (input)
                {
                    case "1": // Add a new customer
                        customerManager.AddanewCustomer();
                        break;

                    case "2": // View customers
                        customerManager.ViewCustomersInformation();
                        break;

                    case "3": // Delete a customer
                        customerManager.DeleteCustomer();
                        break;

                    case "4": // Back to Main Menu
                        backToMainMenu = true;
                        break;

                    default:
                        Console.WriteLine("Sorry but this is an invalid choice. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
