using comp2129_group_project.Entities;
using static comp2129_group_project.Validation.Validation;
using static comp2129_group_project.Entities.Constants;
using static comp2129_group_project.Display.Display;
using static comp2129_group_project.Managers.CustomerManager;
using System;
using System.Linq;

namespace comp2129_group_project.Managers
{
    public class BookingManager
    {
        private static readonly FileManager _fileManager = new();
        private Booking[] bookings = new Booking[100];
        private int currentBookingCount = _fileManager.ReadFile(BOOKINGS_FILE).Length - 1;
        private static CustomerManager customerManager = new CustomerManager(10);
        private static FlightManager flightManager = new FlightManager(10);
        private static Random random = new Random();

        public void MakeNewBooking()
        {
            Console.Clear();
            Console.WriteLine("Creating a new booking...");

            // Check if booking limit has been reached
            if (currentBookingCount >= bookings.Length)
            {
                Console.WriteLine("Cannot create a new booking. Maximum booking limit reached.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Available Customers:");
            customerManager.ViewCustomersInformation();

            Console.WriteLine("\nAvailable Flights:");
            flightManager.ViewFlightsInformation();

            Console.Write("\nEnter Flight ID: ");
            string flightId = Console.ReadLine();
            Console.Write("Enter Customer ID: ");
            string? customerId = Console.ReadLine();
            
            Flight? flight = flightManager.FindFlightById(flightId);
            Customer? customer = customerManager.FindCustomerById(customerId);

            if (flight == null || customer == null)
            {
                Console.WriteLine("Invalid Flight ID or Customer ID.");
                Console.ReadKey();
                return;
            }

            if (flight.NumOfPassengers >= flight.MaxSeats)
            {
                Console.WriteLine("Cannot create booking. The flight is fully booked.");
                Console.ReadKey();
                return;
            }

            // Generate unique BookingNumber: B + First 2 Characters of FlightId + CustomerId + RandomCharacter + RandomNumber
            string flightIdPart = flightId.Substring(0, 2).ToUpper();
            string randomChar = ((char)random.Next('A', 'Z' + 1)).ToString();
            int randomNumber = random.Next(10, 100); // Random 2-digit number
            string bookingNumber = $"B{flightIdPart}{customerId}{randomChar}{randomNumber}";

            // Create the booking
            Booking newBooking = new Booking(bookingNumber, flight, customer);

            // Serialize and save to file
            string content = newBooking.Serialize();
            _fileManager.AppendFile(BOOKINGS_FILE, content + "|");

            bookings[currentBookingCount] = newBooking;
            currentBookingCount++;

            flight.NumOfPassengers++;

            Console.WriteLine($"\nBooking successfully created! Booking Number: {newBooking.BookingNumber}");
            Console.ReadKey();
        }

       public void ViewBookings()
        {
            // Read bookings from the bookings file
            string[] bookings = _fileManager.ReadFile(BOOKINGS_FILE)
                                            .Where(line => !string.IsNullOrWhiteSpace(line)) // Exclude blank lines
                                            .ToArray();

            // Read customers from the customers file
            string[] customers = _fileManager.ReadFile(CUSTOMERS_FILE)
                                            .Where(line => !string.IsNullOrWhiteSpace(line)) // Exclude blank lines
                                            .ToArray();

            if (bookings.Length == 0)
            {
                Console.WriteLine("\nNo bookings found.");
            }
            else
            {
                DisplayAllBookings(bookings, customers);
            }

            Console.ReadKey();
        }

    }
}
