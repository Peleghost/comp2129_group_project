namespace comp2129_group_project.Entities
{
    public class Booking
    {
        public int BookingNumber { get; set; } // Auto-assigned booking number
        public string Date { get; set; } // Date the booking was made
        public Flight Flight { get; set; } // Flight associated with the booking
        public Customer Customer { get; set; } // Customer associated with the booking

        public Booking(int bookingNumber, Flight flight, Customer customer)
        {
            BookingNumber = bookingNumber;
            Date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"); // Date the booking is created
            Flight = flight;
            Customer = customer;
        }
    }
}
