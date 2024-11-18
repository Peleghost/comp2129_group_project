namespace comp2129_group_project.Entities
{
    public class Customer
    {
        private static int i = 0;

        private int Id { get; set; } = ++i; 
        public int CustomerId => Id; 
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Phone { get; set; }
        public int NumOfBookings { get; set; }

        
        public Customer() { }

        public Customer(string firstName, string lastName, string phone)
        {
            FirstName = string.IsNullOrWhiteSpace(firstName) 
                ? throw new ArgumentException("Sorry, but the First name cannot be empty.") 
                : firstName;

            LastName = string.IsNullOrWhiteSpace(lastName) 
                ? "This is an Unknown" 
                : lastName;

            Phone = phone;
        }

        // This will be validates if FirstName is not null or empty
        public bool ValidateFirstName()
        {
            return !string.IsNullOrWhiteSpace(FirstName);
        }

        // this method will be used to display the full name
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
