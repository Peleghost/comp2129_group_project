using System;

namespace comp2129_group_project.Entities
{
    public class Booking
    {
        // Static counter for unique booking IDs
        private static int bookingCounter = 100; // Start with 100 as the initial booking number

        // Unique Booking ID for each booking
        public int BookingId { get; } // Read-only, automatically assigned ID
        public string BookingNum { get; } // Display-friendly booking number
        public string Date { get; }       // Booking date as a formatted string
        public Customer Customer { get; } // Associated customer
        public Flight Flight { get; }     // Associated flight

        // Default constructor (optional, if no default values are needed)
        public Booking() { }

        // Main constructor to create a booking with Customer and Flight
        public Booking(Customer customer, Flight flight)
        {
            // Assign unique BookingId and BookingNum
            BookingId = bookingCounter++;
            BookingNum = BookingId.ToString();

            // Set the date in the required format
            Date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");

            // Associate the booking with the specified customer and flight
            Customer = customer;
            Flight = flight;
        }

        // Override ToString to provide a formatted booking display
        public override string ToString()
        {
            return $"Booking No: {BookingNum}, Date: {Date}, Customer: {Customer.FirstName} {Customer.LastName}, Flight No: {Flight.FlightId}";
        }
    }
}