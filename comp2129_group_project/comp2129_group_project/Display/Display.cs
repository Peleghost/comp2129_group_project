using static System.Console;
using static comp2129_group_project.Util.Util;
using comp2129_group_project.SubMenus;

namespace comp2129_group_project.Display
{
    public class Display
    {
        // Display the main menu
        public static string MenuMain()
        {
            Clear();
            WriteLine("============================================");
            WriteLine("===          FACS Airlines Limited       ===");
            WriteLine("============================================");
            WriteLine("1) Customers");
            WriteLine("2) Flights");
            WriteLine("3) Bookings");
            WriteLine("\n4) Clear Text Files");
            WriteLine("\n0) Exit");
            WriteLine("============================================");
            Write("> ");

            return GetInput(5);
        }

        // Display customers menu
        public static string MenuCustomers()
        {
            Clear();
            WriteLine("============================================");
            WriteLine("===            Customers Menu            ===");
            WriteLine("============================================");
            WriteLine("1) Add Customer");
            WriteLine("2) View Customers");
            WriteLine("3) Delete Customer");
            WriteLine("0) Back to Main Menu");
            WriteLine("============================================");
            Write("> ");

            return GetInput(4);
        }

        public static void DisplayAllCustomers(string[] customers)
        {
            Clear();
            WriteLine("=============================================================");
            WriteLine("| #   | First Name        | Last Name         | Phone Number    |");
            WriteLine("=============================================================");

            int count = 0;
            foreach (string customer in customers)
            {
                if (string.IsNullOrWhiteSpace(customer))
                {
                    continue; // Skip empty lines
                }

                string[] temp = customer.Split(':');

                // Ensure the entry has exactly 4 parts (ID:FirstName:LastName:Phone)
                if (temp.Length == 4)
                {
                    WriteLine($"| {temp[0],-3} | {temp[1],-17} | {temp[2],-17} | {temp[3],-15} |");
                    WriteLine("-------------------------------------------------------------");
                    count++;
                }
                else
                {
                    // Handle malformed entries gracefully
                    WriteLine($"| !!! | Unable to process: {customer.PadRight(50)} |");
                    WriteLine("-------------------------------------------------------------");
                }
            }

            // Display success or no customers message
            if (count == 0)
            {
                WriteLine("| No customers found. Please add customers to view here.    |");
                WriteLine("=============================================================");
            }
            else
            {
                WriteLine($"| Successfully displayed {count} customer(s).                         |");
                WriteLine("=============================================================");
            }
        }

        public static void CustomerExistsMsg()
        {
            Clear();
            WriteLine("============================================");
            WriteLine("===     Customer Already Exists!         ===");
            WriteLine("============================================");
            Thread.Sleep(2000);
        }

        // Display flights menu
        public static string MenuFlights()
        {
            Clear();
            WriteLine("============================================");
            WriteLine("===             Flights Menu             ===");
            WriteLine("============================================");
            WriteLine("1) Add Flight");
            WriteLine("2) View All Flights");
            WriteLine("3) View Particular Flight");
            WriteLine("4) Delete Flight");
            WriteLine("5) Back to Main Menu");
            WriteLine("============================================");
            Write("> ");

            return GetInput(5);
        }

        public static void DisplayAllFlights(string[] flights)
        {
            Clear();
            WriteLine("============================================================================");
            WriteLine("| #   | Flight ID      | Origin         | Destination    | Seats   | Passengers |");
            WriteLine("============================================================================");

            int count = 0;
            foreach (string flight in flights)
            {
                if (string.IsNullOrWhiteSpace(flight))
                {
                    continue; // Skip empty entries
                }

                string[] temp = flight.Split(':');

                if (temp.Length == 5)
                {
                    WriteLine($"| {++count,-3} | {temp[0],-13} | {temp[1],-14} | {temp[2],-14} | {temp[3],-7} | {temp[4],-10} |");
                    WriteLine("----------------------------------------------------------------------------");
                }
                else
                {
                    WriteLine($"| !!! | Unable to process: {flight.PadRight(59)} |");
                    WriteLine("----------------------------------------------------------------------------");
                }
            }

            if (count == 0)
            {
                WriteLine("| No flights found. Please add flights to view here.                       |");
                WriteLine("============================================================================");
            }
            else
            {
                WriteLine($"| Successfully displayed {count} flight(s).                                        |");
                WriteLine("============================================================================");
            }
        }

        // Display bookings menu
        public static string MenuBookings()
        {
            Clear();
            WriteLine("============================================");
            WriteLine("===            Bookings Menu             ===");
            WriteLine("============================================");
            WriteLine("1) Make Booking");
            WriteLine("2) View All Bookings");
            WriteLine("3) Back to Main Menu");
            WriteLine("============================================");
            Write("> ");

            return GetInput(3);
        }

        public static void DisplayAllBookings(string[] bookings)
        {
            Clear();
            WriteLine("==========================================================================");
            WriteLine("| #   | Booking Number  | Flight ID | Customer ID | Date/Time             |");
            WriteLine("==========================================================================");

            int count = 0;
            foreach (string booking in bookings)
            {
                if (string.IsNullOrWhiteSpace(booking))
                {
                    continue; // Skip empty lines
                }

                string[] temp = booking.Split(':');

                if (temp.Length == 5)
                {
                    string dateTime = $"{temp[3]} {temp[4]}";
                    WriteLine($"| {++count,-3} | {temp[0],-15} | {temp[1],-9} | {temp[2],-10} | {dateTime,-21} |");
                    WriteLine("--------------------------------------------------------------------------");
                }
                else
                {
                    WriteLine($"| !!! | Unable to process: {booking.PadRight(60)} |");
                    WriteLine("--------------------------------------------------------------------------");
                }
            }

            if (count == 0)
            {
                WriteLine("| No bookings found. Please add bookings to view here.                   |");
                WriteLine("==========================================================================");
            }
            else
            {
                WriteLine($"| Successfully displayed {count} booking(s).                                   |");
                WriteLine("==========================================================================");
            }
        }

        public static void MenuExit()
        {
            Clear();
            WriteLine("============================================");
            WriteLine("===          Goodbye! See you soon!      ===");
            WriteLine("============================================");
            Thread.Sleep(1500);
        }
    }
}
