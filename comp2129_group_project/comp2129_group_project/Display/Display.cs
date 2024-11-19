﻿using static System.Console;
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
            WriteLine("-----------------------------");
            WriteLine("--- FACS Airlines Limited ---");
            WriteLine("-----------------------------\n");
            WriteLine("1) Customers");
            WriteLine("2) Flights");
            WriteLine("3) Bookings");
            WriteLine("\n4) CLEAR TXT FILES");
            WriteLine("\n0) Exit");
            WriteLine("-----------------------------");
            Write("> ");

            return GetInput(5);
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

        public static void DisplayAllCustomers(string[] customers)
        {
            Clear();
            WriteLine("-----------------");
            WriteLine("- All Customers -");
            WriteLine("-----------------");

            WriteLine("-----------------------------------------");
            WriteLine("- First Name | Last Name | Phone Number -");
            WriteLine("-----------------------------------------");

            int count = 0;
            foreach (string customer in customers)
            {
                if (string.IsNullOrEmpty(customer))
                {
                    continue;
                }

                string[] temp = customer.Split(':');
                WriteLine($"{++count}) {temp[0]} | {temp[1]} | {temp[2]}");
                WriteLine("---------------------------------------");
            }
        }

        public static void CustomerExistsMsg()
        {
            Clear();
            WriteLine("\n-----------------------------------");
            WriteLine("- Sorry, customer already exists. -");
            WriteLine("-----------------------------------");
            Thread.Sleep(2000);
        }

        // Display flights menu
        public static string MenuFlights()
        {
            Clear();
            WriteLine("-----------------------------");
            WriteLine("---------- Flights ----------");
            WriteLine("-----------------------------");
            WriteLine("1) Add Flight");
            WriteLine("2) View Flights");
            WriteLine("3) View Particular Flight");
            WriteLine("4) Delete Flight\n");
            WriteLine("5) Main Menu");
            WriteLine("-----------------------------");
            Write("> ");

            return GetInput(5);
        }
        
        public static void DisplayAllFlights(string[] flights)
        {

            WriteLine("-----------------------------------------------------------------");
            WriteLine("- Flight Number | Origin | Destination | Max Seats | Passengers -");
            WriteLine("-----------------------------------------------------------------");

            int count = 0;
            foreach (string flight in flights)
            {
                if (string.IsNullOrEmpty(flight))
                {
                    continue;
                }

                string[] temp = flight.Split(':');
                WriteLine($"{temp[0]} | {temp[1]} | {temp[2]} | {temp[3]} | {temp[4]}");
                WriteLine("-----------------------------------------------------------------");
            }
        }
        // Display booking menu
        public static string MenuBookings()
        {
            Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------- Booking Menu ---------");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1) Make Booking");
            Console.WriteLine("2) View Bookings");
            Console.WriteLine("3) Back to main menu");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
        
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
