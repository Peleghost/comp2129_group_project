using static comp2129_group_project.Display.Display;
using comp2129_group_project.Managers;
using static comp2129_group_project.SubMenus.CustomerMenu;
using static comp2129_group_project.SubMenus.BookingMenu;
using static comp2129_group_project.SubMenus.FlightMenu;
using static comp2129_group_project.Managers.FileManager;


namespace comp2129_group_project
{
    //---------------------------------------------
    //--------- COMP 2129 - Group Project ---------
    //
    // Members:
    //
    // Fellipe C.T.C - 101497831
    // Ayesha Akbar -- 100949840
    // Claire Lee ---- 100882058
    // Suthan S. -----
    //                         
    //---------------------------------------------
    internal class Program
    {
        // Used to clear all txt files, may be removed before submitting
        private static readonly FileManager _fileManager = new();

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
                        HandleFlightMenu(); 
                        userInput = MenuMain();
                        break;

                    // Bookings
                    case "3":
                        HandleBookingMenu(); 
                        userInput = MenuMain();
                        break;

                    case "4":
                        Console.WriteLine("\nType 'clear' to clear all txt files.");
                        string input = Console.ReadLine()!;

                        while (input != "clear")
                        {
                            Console.WriteLine("\nType 'clear' to clear all txt files.");
                            input = Console.ReadLine()!;
                        }
                        
                        _fileManager.ClearAllTxtFiles();
                        
                        userInput = MenuMain();
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
    }
}
