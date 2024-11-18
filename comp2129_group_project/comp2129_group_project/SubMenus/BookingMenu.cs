using comp2129_group_project.Managers;
using static comp2129_group_project.Display.Display;

namespace comp2129_group_project.SubMenus
{
    public static class BookingMenu
    {
        private static readonly BookingManager bookingManager = new BookingManager(); // Handles booking operations

        public static void HandleBookingMenu()
        {
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                string input = MenuBookings(); 

                switch (input)
                {
                    case "1":
                        bookingManager.MakeNewBooking();
                        break;

                    case "2": 
                        bookingManager.ViewBookings();
                        break;

                    case "3": 
                        backToMainMenu = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
