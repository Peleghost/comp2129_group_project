namespace comp2129_group_project.Entities
{
    public class Flight
    {
        // Auto increment id for each new flight created
        private static int i = 0;
        private static Random random = new Random();
        private static int maxSeats = random.Next(30, 51);

        public int FlightId { get; private set; } = ++i;
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public int MaxSeats { get; set; } = maxSeats;
        public int NumOfPassengers { get; set; } = maxSeats - random.Next(2, 5);

        public Flight(string origin, string destination)
        {
            Origin = origin;
            Destination = destination;
        }
    }
}
