namespace comp2129_group_project.Entities
{
    public class Booking
    {
        public string BookingNumber { get; private set; } 
        public string Date { get; private set; }
        public Flight Flight { get; private set; } 
        public Customer Customer { get; private set; }
        private static Random random = new Random();

        // Constructor for new bookings
        public Booking(Flight flight, Customer customer)
        {
            Flight = flight ?? throw new ArgumentNullException(nameof(flight));
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            Date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");

            // Generate BookingNumber: B + First2LettersOfFlightId + CustomerId + RandomCharacter + RandomNumber
            string flightIdPart = flight.FlightId.Substring(0, 2).ToUpper();
            string randomChar = ((char)random.Next('A', 'Z' + 1)).ToString(); // Random uppercase letter
            int randomNumber = random.Next(10, 100); // Random 2-digit number
            BookingNumber = $"B{flightIdPart}{customer.CustomerId}{randomChar}{randomNumber}";
        }

        // Constructor for existing bookings 
        public Booking(string bookingNumber, Flight flight, Customer customer, string date)
        {
            BookingNumber = bookingNumber ?? throw new ArgumentNullException(nameof(bookingNumber));
            Flight = flight ?? throw new ArgumentNullException(nameof(flight));
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            Date = date ?? throw new ArgumentNullException(nameof(date));
        }

        // Overload constructor for creating a booking without a date
        public Booking(string bookingNumber, Flight flight, Customer customer)
        {
            BookingNumber = bookingNumber ?? throw new ArgumentNullException(nameof(bookingNumber));
            Flight = flight ?? throw new ArgumentNullException(nameof(flight));
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            Date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
        }

        // Serialize booking details into a string for saving to file
        public string Serialize()
        {
            return $"{BookingNumber}:{Flight.FlightId}:{Customer.CustomerId}:{Date}";
        }
    }
}
