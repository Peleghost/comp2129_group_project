using System;
using comp2129_group_project.Entities;
using comp2129_group_project.Util;

namespace comp2129_group_project.BookingSubMenu
{
    public class BookingMenu
    {
        private string[] bookings = new string[100]; // Fixed-size array for bookings
        private int bookingCount = 0; // Counter to keep track of bookings
        private Customer[] customers; // Array of existing customers
        private Flight[] flights;     // Array of existing flights

        // Constructor accepts existing customers and flights arrays
        public BookingMenu(Customer[] customers, Flight[] flights)
        {
            this.customers = customers;
            this.flights = flights;
        }

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

            // Display existing customers
            Console.WriteLine("Available Customers:");
            foreach (var customer in customers)
            {
                if (customer != null)
                    Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}");
            }

            // Get and validate customer ID
            Console.Write("Enter customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int customerId) || !IsValidCustomerId(customerId))
            {
                Console.WriteLine("Invalid customer ID.");
                return;
            }

            // Display existing flights
            Console.WriteLine("\nAvailable Flights:");
            foreach (var flight in flights)
            {
                if (flight != null)
                    Console.WriteLine($"Flight No: {flight.FlightId}, Origin: {flight.Origin}, Destination: {flight.Destination}");
            }

            // Get and validate flight ID
            Console.Write("Enter flight ID: ");
            if (!int.TryParse(Console.ReadLine(), out int flightId) || !IsValidFlightId(flightId))
            {
                Console.WriteLine("Invalid flight ID.");
                return;
            }

            // Check if we can add another booking
            if (bookingCount >= bookings.Length)
            {
                Console.WriteLine("Unable to create booking. Booking limit reached.");
                return;
            }

            // Create the booking entry
            string bookingDetails = $"Customer ID: {customerId}, Flight ID: {flightId}, Date: {DateTime.Now:yyyy-MM-dd}";
            bookings[bookingCount++] = bookingDetails;
            Console.WriteLine("Booking successfully created!");
        }

        private void ViewBookings()
        {
            Console.Clear();
            Console.WriteLine("View Bookings");

            if (bookingCount > 0)
            {
                for (int i = 0; i < bookingCount; i++)
                {
                    Console.WriteLine(bookings[i]);
                }
            }
            else
            {
                Console.WriteLine("No bookings found.");
            }
        }

        // Helper method to verify customer ID exists in customers array
        private bool IsValidCustomerId(int customerId)
        {
            foreach (var customer in customers)
            {
                if (customer != null && customer.CustomerId == customerId)
                    return true;
            }
            return false;
        }

        // Helper method to verify flight ID exists in flights array
        private bool IsValidFlightId(int flightId)
        {
            foreach (var flight in flights)
            {
                if (flight != null && flight.FlightId == flightId)
                    return true;
            }
            return false;
        }
    }
}
