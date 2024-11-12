namespace comp2129_group_project.Entities
{
    public class Flight
    {
        // Auto increment id for each new flight created
        // on the shell instance
        private static int i = 0;
        private static int maxSeats = new Random().Next(30, 51);

        private int Id { get; set; } = ++i;
        public int FlightId { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }

        // Set a random MaxSeats value
        public int MaxSeats { get; set; } = maxSeats;

        // Set a random number of max passengers
        // to test full flights error handling
        public int NumOfPassengers { get; set; } = maxSeats - new Random().Next(2, 5);  

        public Flight()
        {
        }

        public Flight(string origin, string destination)
        {
            FlightId = Id;
            Origin = origin;
            Destination = destination;
        }
    }
}
