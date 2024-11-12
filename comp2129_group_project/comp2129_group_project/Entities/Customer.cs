namespace comp2129_group_project.Entities
{
    public class Customer
    {
        // Auto increment id for each new customer created
        // on the shell instance
        private static int i = 0;

        private int Id { get; set; } = ++i;
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int NumOfFlights { get; set; }

        public Customer()
        {
        }

        public Customer(string firstName, string lastName, int numOfFlights)
        {
            CustomerId = Id;
            FirstName = firstName;
            LastName = lastName;
            NumOfFlights = numOfFlights;
        }
    }
}
