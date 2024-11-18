using static comp2129_group_project.Display.Display;
using comp2129_group_project.Managers;
using static comp2129_group_project.SubMenus.CustomerMenu;
using static comp2129_group_project.SubMenus.BookingMenu;
using static comp2129_group_project.SubMenus.FlightMenu;


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
