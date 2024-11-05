using static System.Console;
using static comp2129_group_project.Util.Util;

namespace comp2129_group_project.Display
{
    public class Display
    {
        // Display the main menu
        public static string MenuMain()
        {
            Clear();
            WriteLine("-----------------------------");
            WriteLine("--- FACS Airlines Limited ---");
            WriteLine("-----------------------------\n");
            WriteLine("1) Customers");
            WriteLine("2) Flights");
            WriteLine("3) Bookings\n");
            WriteLine("0) Exit");
            WriteLine("-----------------------------");
            Write("> ");

            return GetInput(4);
        }

        // Display customers menu
        public static string MenuCustomers()
        {
            Clear();
            WriteLine("-----------------------------");
            WriteLine("--------- Customers ---------");
            WriteLine("-----------------------------\n");
            WriteLine("1) Add Customer");
            WriteLine("2) View Customers");
            WriteLine("3) Delete Customer\n");
            WriteLine("0) Main Menu");
            WriteLine("-----------------------------");
            Write("> ");

            return GetInput(4);
        }

        // Display flights menu
        public static string MenuFilghts()
        {
            Clear();
            WriteLine("-----------------------------");
            WriteLine("---------- Flights ----------");
            WriteLine("-----------------------------");
            WriteLine("1) Add Flight");
            WriteLine("2) View Flights");
            WriteLine("3) View Particular Flight");
            WriteLine("4) Delete Flight\n");
            WriteLine("0) Main Menu");
            WriteLine("-----------------------------");
            Write("> ");

            return GetInput(5);
        }

        // Display bookings menu
        public static string MenuBookings()
        {
            Clear();
            WriteLine("------------------------------");
            WriteLine("---------- Bookings ----------");
            WriteLine("------------------------------");
            WriteLine("1) Make Booking");
            WriteLine("2) View Bookings\n");
            WriteLine("0) Main Menu");
            WriteLine("------------------------------");
            Write("> ");

            return GetInput(3);
        }

        // Display exit menu
        public static void MenuExit()
        {
            Clear();
            WriteLine("------------------------------");
            WriteLine("---------- Goodbye! ----------");
            WriteLine("------------------------------");
            Thread.Sleep(1500);
        }
    }
}
