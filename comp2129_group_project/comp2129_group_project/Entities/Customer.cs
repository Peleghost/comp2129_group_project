namespace comp2129_group_project.Entities
{
    public class Customer
    {
        //private static int i = 0;

        public int CustomerId { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Phone { get; set; }
        public int NumOfBookings { get; set; }

        public Customer() { }

        public Customer(int id, string firstName, string lastName, string phone)
        {
            CustomerId = id;

            FirstName = string.IsNullOrWhiteSpace(firstName) 
                ? throw new ArgumentException("Sorry, but the First name cannot be empty.") 
                : firstName;

            LastName = string.IsNullOrWhiteSpace(lastName) 
                ? "This is an Unknown" 
                : lastName;

            Phone = phone;
        }

        // Serialize customer data as a single line
        public string Serialize()
        {
            return $"{CustomerId}:{FirstName}:{LastName}:{Phone}";
        }

       
    }
}
