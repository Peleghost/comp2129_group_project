using System;
using System.Collections.Generic;
using comp2129_group_project.Util;

namespace comp2129_group_project.BookingSubMenu
{
    public class BookingMenu
    {
        private List<string> bookings = new List<string>();

        public void ShowBookingMenu()
        {
            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("---------- Booking Menu ---------");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1) Make Booking");
                Console.WriteLine("2) View Bookings");
                Console.WriteLine("3) Back to main menu");
                Console.WriteLine("---------------------------------");
                Console.Write("> ");

                choice = Util.Util.GetInput(3); 

                switch (choice)
                {
                    case "1":
                        MakeBooking();
                        break;
                    case "2":
                        ViewBookings();
                        break;
                    case "3":
                        Console.WriteLine("Returning to main menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

            } while (choice != "3");
        }

        private void MakeBooking()
        {
            Console.Clear();
            Console.WriteLine("Make a Booking");

            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine() ?? "" ;

            Console.Write("Enter flight number: ");
            string flightNumber = Console.ReadLine() ?? "";

            Console.Write("Enter booking date (YYYY-MM-DD): ");
            string bookingDate = Console.ReadLine() ?? "";

            if (!string.IsNullOrEmpty(customerName) && !string.IsNullOrEmpty(flightNumber) && DateTime.TryParse(bookingDate, out DateTime date))
            {
                string bookingDetails = $"Customer: {customerName}, Flight: {flightNumber}, Date: {date.ToShortDateString()}";
                bookings.Add(bookingDetails);
                Console.WriteLine("Booking successfully created!");
            }
            else
            {
                Console.WriteLine("Invalid input. Please make sure all fields are filled correctly.");
            }
        }

        private void ViewBookings()
        {
            Console.Clear();
            Console.WriteLine("View Bookings");

            if (bookings.Count > 0)
            {
                foreach (var booking in bookings)
                {
                    Console.WriteLine(booking);
                }
            }
            else
            {
                Console.WriteLine("No bookings found.");
            }
        }
    }
}
