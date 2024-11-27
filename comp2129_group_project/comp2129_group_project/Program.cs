using static comp2129_group_project.Display.Display;
using comp2129_group_project.Managers;
using static comp2129_group_project.SubMenus.CustomerMenu;
using static comp2129_group_project.SubMenus.BookingMenu;
using static comp2129_group_project.SubMenus.FlightMenu;
using static comp2129_group_project.Managers.FileManager;

//
// === COMP 2129 Advanced OOP - Group Project ===
// 
// ---------- Flight Management System ----------
//
// Group Members: 
//
// Fellipe C.T Camargo ------- 101497831 
// Ayesha Akbar -------------- 100949840
// Claire Lee ---------------- 100882058
// Suthan Sureshkumar -------- 101511337
//

namespace comp2129_group_project
{
    internal class Program
    {
        private static readonly FileManager _fileManager = new();

        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();
            fileManager.CreateFiles();

            string userInput = MenuMain();
            bool quit = false;

            while (!quit)
            {
                switch (userInput)
                {
                    case "1":
                        HandleCustomerMenu();
                        userInput = MenuMain();
                        break;

                    case "2":
                        HandleFlightMenu(); 
                        userInput = MenuMain();
                        break;

                    case "3":
                        HandleBookingMenu(); 
                        userInput = MenuMain();
                        break;

                    case "4":
                        Console.WriteLine("\nType 'clear' to clear all txt files or type 'back' to return to the previous menu.");
                        string input = Console.ReadLine()!;

                        while (input != "clear" && input != "back")
                        {
                            Console.WriteLine("\nType 'clear' to clear all txt files or type 'back' to return to the previous menu.");
                            input = Console.ReadLine()!;
                        }

                        if (input == "clear")
                        {
                            _fileManager.ClearAllTxtFiles();
                            Console.WriteLine("All txt files have been cleared.");
                        }
                        else if (input == "back")
                        {
                            Console.WriteLine("Returning to the previous menu...");
                            userInput = MenuMain();  // Go back to the main menu or previous menu
                            break;
                        }

                        userInput = MenuMain();  // Show the main menu again after clearing
                        break; ;    

                    case "0":
                        MenuExit();
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        quit = true;
                        break;
                }
            }
        }
    }
}
