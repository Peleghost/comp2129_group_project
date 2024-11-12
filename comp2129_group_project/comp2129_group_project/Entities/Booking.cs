namespace comp2129_group_project.Entities
{
    public class Booking
    {
        // Auto increment id for each new booking created
        // on the shell instance
        private static int i = 0;

        private int Id { get; set; } = ++i;

        // BookingId to be used for internal querying purposes
        // May be removed if not useful
        public int BookingId { get; set; }

        public string? BookingNum { get; set; } = new Random().Next(100, 999).ToString();
        public DateTime Date { get; set; } = DateTime.Now;
        public Customer? Customer { get; set; }
        public Flight? Flight { get; set; }

        public Booking()
        {
        }

        public Booking(string bookingNum, Customer customer, Flight flight)
        {
            BookingId = Id;
            BookingNum = bookingNum;
            Customer = customer;
            Flight = flight;
        }
    }
}
