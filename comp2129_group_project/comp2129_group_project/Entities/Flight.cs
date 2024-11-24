namespace comp2129_group_project.Entities
{
    public class Flight
    {
        private static Random random = new Random();
        private static int flightCounter = 0; // Static counter for unique FlightId suffix

        public string FlightId { get; private set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public int MaxSeats { get; set; }
        public int NumOfPassengers { get; set; }

        // Constructor for new flights
        public Flight(string origin, string destination)
        { 
            MaxSeats = random.Next(30, 51); // Random max seats between 30 and 50
            NumOfPassengers = MaxSeats - random.Next(2, 5); // Random passengers, between MaxSeats-5 and MaxSeats-2

            flightCounter++;
            FlightId = $"{origin[0].ToString().ToUpper()}{destination[0].ToString().ToUpper()}{MaxSeats}{flightCounter}";

        }

        // Constructor for existing flights
        public Flight(string flightId, string origin, string destination, int maxSeats, int numOfPassengers)
        {
            FlightId = flightId ?? throw new ArgumentNullException(nameof(flightId), "FlightId cannot be null");
            Origin = origin ?? throw new ArgumentNullException(nameof(origin), "Origin cannot be null");
            Destination = destination ?? throw new ArgumentNullException(nameof(destination), "Destination cannot be null");

            MaxSeats = maxSeats;
            NumOfPassengers = numOfPassengers;
        }
    }
}
