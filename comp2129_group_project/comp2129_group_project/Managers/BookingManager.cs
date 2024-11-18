using comp2129_group_project.Entities;
using comp2129_group_project.Managers;
using System;

namespace comp2129_group_project.Managers
{
    public class BookingManager
    {
        private Booking[] bookings = new Booking[100]; // Array to store bookings
        private int bookingNumberCounter = 1; // Auto-increment booking number
        private int currentBookingCount = 0; // Track the number of bookings

        private static CustomerManager customerManager = new CustomerManager(10); // Assuming a max of 10 customers
        private static FlightManager flightManager = new FlightManager(10); // Assuming a max of 10 flights

        public void MakeNewBooking()
        {
            Console.Clear();
            Console.WriteLine("Creating a new booking...");

            // Check if the bookings array is full
            if (currentBookingCount >= bookings.Length)
            {
                Console.WriteLine("Cannot create new booking. Maximum booking limit reached.");
                Console.ReadKey();
                return;
            }

            // Display all customers
            Console.WriteLine("Available Customers:");
            customerManager.ViewCustomersInformation();

            // Display all flights
            Console.WriteLine("\nAvailable Flights:");
            flightManager.ViewFlightsInformation();

            // Get flight and customer IDs
            Console.Write("\nEnter Flight ID: ");
            string flightId = Console.ReadLine();
            Console.Write("Enter Customer ID: ");
            string customerId = Console.ReadLine();

            // Validate flight and customer objects
            Flight? flight = flightManager.FindFlightById(flightId);
            Customer? customer = customerManager.FindCustomerById(customerId);

            if (flight == null)
            {
                Console.WriteLine("Invalid Flight ID.");
                Console.ReadKey();
                return;
            }

            if (customer == null)
            {
                Console.WriteLine("Invalid Customer ID.");
                Console.ReadKey();
                return;
            }

            // Check if the flight has available seats
            if (flight.NumOfPassengers >= flight.MaxSeats)
            {
                Console.WriteLine("Cannot create booking. The flight is fully booked.");
                Console.ReadKey();
                return;
            }

            // Create a new booking
            Booking newBooking = new Booking(bookingNumberCounter++, flight, customer);

            // Add the booking to the array
            bookings[currentBookingCount] = newBooking;
            currentBookingCount++;

            // Update the flight's passenger count
            flight.NumOfPassengers++;

            Console.WriteLine($"\nBooking successfully created! Booking Number: {newBooking.BookingNumber}");
            Console.ReadKey();
        }

        public void ViewBookings()
        {
            Console.Clear();
            Console.WriteLine("Viewing all bookings...");

            // Check if there are no bookings
            if (currentBookingCount == 0)
            {
                Console.WriteLine("No bookings available.");
                Console.ReadKey();
                return;
            }

            // Display all bookings
            for (int i = 0; i < currentBookingCount; i++)
            {
                Booking booking = bookings[i];
                Console.WriteLine($"Booking Number: {booking.BookingNumber}, Date: {booking.Date}, " +
                                  $"Flight: {booking.Flight.FlightId}, Customer: {booking.Customer.FirstName} {booking.Customer.LastName}");
            }
            Console.ReadKey();
        }
    }
}
